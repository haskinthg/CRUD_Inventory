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
    public partial class OutProduct
    {
        public int OutId { get; set; }
        public System.DateTime OutDate { get; set; }
        public int OutCount { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
