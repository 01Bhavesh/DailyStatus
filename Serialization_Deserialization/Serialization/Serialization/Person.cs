﻿using System;

namespace Serialization
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
    }
}