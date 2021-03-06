﻿using System;
using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using Smod2.EventHandlers;
using Smod2.Events;

namespace EnterTheJuggernaut
{
	[PluginDetails(
		author = "Phoenix",
		name = "EnterTheJuggernaut",
		description = "Gamemode plugin for SCP: Secret Laboratory",
		id = "phoenix.etj",
		configPrefix = "etj",
		version = "1.0.1",
		SmodMajor = 3,
		SmodMinor = 4,
		SmodRevision = 0
		)]

	public partial class EnterTheJuggernaut : Plugin
    {

		public bool ETJdisable { get; private set; }
		public int ETJhp { get; private set; }
		public string[] ETJranks { get; private set; }

		public bool Enabled { get; set; }

		public override void OnDisable()
		{
			this.Info(Details.name + " was disabled");
		}
		public override void OnEnable()
		{
			this.Info(Details.name + " was enabled");
		}
		public override void Register()
		{
			this.AddEventHandlers(new EventHandler(this));
			this.AddEventHandler(typeof(IEventHandlerPlayerJoin), new EventHandler(this), Priority.High);
			this.AddCommand("juggernaut", new CommandHandler(this));

			this.AddConfig(new ConfigSetting("etj_disable", false, false, true, "Disabled the ETJ plugin"));
			this.AddConfig(new ConfigSetting("etj_hp", 6000, false, true, "Starting HP for the juggernaut"));
			this.AddConfig(new ConfigSetting("etj_ranks", new[] { "owner" }, false, true, "List of ranks that can trigger EnterTheJuggernaut"));
		}
		public void RefreshConfig()
		{
			ETJdisable = GetConfigBool("etj_disable");
			ETJhp = GetConfigInt("etj_hp");
			ETJranks = GetConfigList("etj_ranks");
		}
	}
}
