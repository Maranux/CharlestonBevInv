//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CBevInc
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Finished_Goods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Finished_Goods()
        {
            this.Recipes = new ObservableCollection<Recipe>();
        }
    
        public double FGID { get; set; }
        public string Description { get; set; }
        public Nullable<double> Price { get; set; }
        public string Packaging { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Recipe> Recipes { get; set; }
    }
}