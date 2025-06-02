ALTER PROCEDURE usp_GetOutsideGeoFenceInfo 
@UserId INT, 
@FromDate DATETIME, 
@ToDate DATETIME, 
@From INT = 1, 
@To INT = 10, 
@Search VARCHAR(200), 
@TotalRecords INT OUTPUT -- TotalRecords missing           
AS 
BEGIN 
SET 
  NOCOUNT ON;
SET 
  TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
SET 
  @From = CASE WHEN @From = 0 THEN 1 ELSE @From END;
with GeoFencingDataCount as(
  SELECT 
    gfi.Id, 
    gfi.CreatedDate as CreatedDate, 
    t.UserName as UserName, 
    cl.LeadName as LeadName, 
    u.EmployeeNo as EmployeeNo, 
    (
      CASE WHEN (
        CAST(
          GETDATE() AS DATE
        ) > CAST(gfi.CreatedDate AS DATE) 
        AND gfi.StatusId = 1
      ) THEN 'Expired' ELSE sm.STATUS END
    ) AS STATUS 
  FROM 
    OutSideGeoFenceInfo gfi 
    INNER JOIN fn_GetMyTeam(@UserId) t ON gfi.UserId = t.UserId 
    INNER JOIN [User] u ON gfi.UserId = u.UserId 
    INNER JOIN CRMLead cl ON gfi.LeadId = cl.Id 
    INNER JOIN OutSideGeoFenceStatusMaster sm ON sm.Id = gfi.StatusId 
    LEFT JOIN [User] um ON um.UserId = gfi.ModifiedBy
) 
select 
  @TotalRecords = count(1) 
from 
  GeoFencingDataCount 
WHERE 
  CreatedDate BETWEEN @FromDate 
  AND @ToDate 
  AND (
    @Search IS NULL 
    OR (
      UserName LIKE '%' + @Search + '%' 
      OR LeadName LIKE '%' + @Search + '%' 
      OR EmployeeNo LIKE '%' + @Search + '%' 
      OR STATUS lIKE '%' + @Search + '%'
    )
  );
with GeoFencingData as(
  SELECT 
    gfi.Id, 
    t.UserName as UserName, 
    u.EmployeeNo as EmployeeNo, 
    cl.LeadName as LeadName, 
    cl.Address as ActualLocation, 
    cl.Latitude, 
    cl.Longitude, 
    gfi.Latitude AS GeoLatitude, 
    gfi.Longitude AS GeoLongitude, 
    gfi.Address as CurrentLocation, 
    gfi.Distance, 
    CAST(
      FORMAT(
        gfi.CreatedDate, 'MM-dd-yyyy hh:mm:ss tt'
      ) AS VARCHAR(25)
    ) AS CreatedDate, 
    gfi.CreatedBy, 
    gfi.ModifiedBy, 
    t.ManagerName, 
    um.[Name] as ActionBy, 
    (
      CASE WHEN (
        CAST(
          GETDATE() AS DATE
        ) > CAST(gfi.CreatedDate AS DATE) 
        AND gfi.StatusId = 1
      ) THEN 'Expired' ELSE sm.STATUS END
    ) AS STATUS, 
    gfi.Remark 
  FROM 
    OutSideGeoFenceInfo gfi 
    INNER JOIN fn_GetMyTeam(@UserId) t ON gfi.UserId = t.UserId 
    INNER JOIN [User] u ON gfi.UserId = u.UserId 
    INNER JOIN CRMLead cl ON gfi.LeadId = cl.Id 
    INNER JOIN OutSideGeoFenceStatusMaster sm ON sm.Id = gfi.StatusId 
    LEFT JOIN [User] um ON um.UserId = gfi.ModifiedBy
) 
select 
  * 
from 
  GeoFencingData 
WHERE 
  CreatedDate BETWEEN @FromDate 
  AND @ToDate 
  AND (
    @Search IS NULL 
    OR (
      UserName LIKE '%' + @Search + '%' 
      OR LeadName LIKE '%' + @Search + '%' 
      OR EmployeeNo LIKE '%' + @Search + '%' 
      OR STATUS lIKE '%' + @Search + '%'
    )
  ) 
ORDER BY 
  CreatedDate DESC OFFSET (@From -1) ROWS FETCH NEXT CASE WHEN @To = -1 
  AND @TotalRecords > 0 THEN @TotalRecords WHEN @To = -1 
  AND @TotalRecords = 0 THEN 10 ELSE @To END ROWS ONLY END;
