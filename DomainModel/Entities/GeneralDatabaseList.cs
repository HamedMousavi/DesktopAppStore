using System;
using System.Collections.Generic;
using System.Collections;



namespace DomainModel.Entities
{
    public class GeneralDatabaseList
    {
        public int TotalCount { get; set; }
        public IEnumerable List { get; set; }
    }
}
