using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuLib.Model.Entities
{
	public class Base
	{
		public override bool Equals(object obj)
		{
			if (obj is Base)
				return ((Base)obj).Id == Id;
			return base.Equals(obj);
		}
		public override int GetHashCode() => Id.GetHashCode();
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();
	}
}
