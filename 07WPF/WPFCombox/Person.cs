using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCombox
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }


        [Display(Name = "P.S.")] // 添加此特性
        [JsonProperty("P.S.")]
        public string Ps { get; set; }
    }
}
