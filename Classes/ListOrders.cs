//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Food.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListOrders
    {
        public int id_ListOrders { get; set; }
        public Nullable<int> id_Order { get; set; }
        public Nullable<int> id_Dishes { get; set; }
    
        public virtual Dishes Dishes { get; set; }
        public virtual Order Order { get; set; }
    }
}
