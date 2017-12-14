//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballAppMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            this.UserAndGamesPivot = new HashSet<UserAndGamesPivot>();
        }
    
        public int Id { get; set; }
        public int Team1_id { get; set; }
        public int Team2_id { get; set; }
        public System.DateTime Date { get; set; }
        public string Score { get; set; }
        public string Name { get; set; }
    
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAndGamesPivot> UserAndGamesPivot { get; set; }
    }
}