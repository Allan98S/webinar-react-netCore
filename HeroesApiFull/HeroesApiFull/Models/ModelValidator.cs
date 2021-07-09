using System;
namespace TSV.Backend.Models
{
    public interface ModelValidator
    {
        /// <summary>
        /// Throws an exception if there is an exception
        /// </summary>
        void ValidateModel();
    }
}
