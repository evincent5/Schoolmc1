using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Schoolmc1.Common
{
    public class RemoteClientServerAttribute : RemoteAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    Type controller = Assembly.GetExecutingAssembly().GetTypes()
        //        .FirstOrDefault(type => type.Name.ToLower() == string.Format("{0}controller", this
        //        .RouteData["controller"].ToString()).ToLower());
        //    if (controller != null)
        //    {
        //        controller.GetMethods().FirstOrDefault(method => method.Name.ToLower() ==
        //        this.RouteData["action"].ToString()
        //    }
        //}

    }
}