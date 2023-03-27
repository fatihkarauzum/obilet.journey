using Obilet.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Core.Attributes {
	public class CacheableAttribute : BaseAttribute {

		public string Key { get; set; } = null!;

		public int ExpirationDay { get; set; } = ExpirationConstant.ONE_DAY;

	}
}
