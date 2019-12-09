using System;

namespace MVC.Models
{
    /// <summary>
    /// ����������� ���� �������. ̳����� ���������� ��� ��������� ���������� ��� �����
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
