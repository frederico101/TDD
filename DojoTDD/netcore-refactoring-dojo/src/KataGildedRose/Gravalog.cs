using System;

namespace KataGildedRose
{
    public class Gravalog : Exception
    {
        public Gravalog(string log) : base(log){}
        public Gravalog() : base (){}

        
    }
}