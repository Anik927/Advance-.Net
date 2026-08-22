using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EF
{
    public class Admin : User
	{		
		
		[Required,Range(1,3,ErrorMessage ="Invalid admin Level")]
		public int AdminLevel { get; set; }



	}
}
