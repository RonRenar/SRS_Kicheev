//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1Pr3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long WorkerId { get; set; }
    
        public virtual Workers Workers { get; set; }
    }
}
