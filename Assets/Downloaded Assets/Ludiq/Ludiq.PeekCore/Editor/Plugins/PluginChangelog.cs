using System;
using System.Collections.Generic;

namespace Ludiq.PeekCore
{
	public abstract class PluginChangelog : IPluginAddon, IComparable<PluginChangelog>
	{
		protected PluginChangelog(Plugin plugin)
		{
			this.plugin = plugin;
		}

		public Plugin plugin { get; }

		public abstract SemanticVersion version { get; }
		public abstract DateTime date { get; }
		public abstract IEnumerable<string> changes { get; }
		public virtual string description => null;

		public int CompareTo(PluginChangelog other)
		{
			return version.CompareTo(other.version);
		}
	}
}