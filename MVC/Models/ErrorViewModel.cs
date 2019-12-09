using System;

namespace MVC.Models
{
    /// <summary>
    /// Представляє клас помилки. Містить властивості для зберігання інформації про книгу
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
