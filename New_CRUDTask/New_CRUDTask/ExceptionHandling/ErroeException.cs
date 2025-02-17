namespace New_CRUDTask.ExceptionHandling
{
    public class ErroeException
    {
        public int StatusCode { get; set; }
        public string? Title { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? Details { get; set; }

    }
}
