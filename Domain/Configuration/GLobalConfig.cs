﻿namespace Domain.Configuration
{
    public class GLobalConfig
    {
        public IEnumerable<KeyValuePair<string,string>> Sources { get; set; }
        public string BitStampUrl { get; set; }
        public string BitFinexUrl { get; set; }
    }
}
