//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kindergarten1
{
    using System;
    using System.Collections.Generic;
    
    public partial class raspisanie
    {
        public int Id_rasp { get; set; }
        public string Day { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public int Id_krygok { get; set; }
    
        public virtual krygok krygok { get; set; }
    }
}