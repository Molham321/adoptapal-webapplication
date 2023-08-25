/*
 * File: ErrorViewModel.cs
 * Namespace: Adoptapal.Web.Models
 * 
 * Description:
 * This file contains the implementation of the ErrorViewModel class, which is used
 * to represent error information when rendering error views.
 * 
 */

namespace Adoptapal.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}