//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CR.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaseType
    {
        public BaseType()
        {
            this.Bases = new HashSet<Base>();
            this.BaseFieldsTemplates = new HashSet<BaseFieldsTemplate>();
        }
    
        public int IdContractType { get; set; }
        public string NameContractType { get; set; }
    
        public virtual ICollection<Base> Bases { get; set; }
        public virtual ICollection<BaseFieldsTemplate> BaseFieldsTemplates { get; set; }
    }
}
