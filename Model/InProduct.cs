//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Inventory.Model
{
    public partial class InProduct
    {
        public int InId { get; set; }
        public System.DateTime InDate { get; set; }
        public int InCount { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
