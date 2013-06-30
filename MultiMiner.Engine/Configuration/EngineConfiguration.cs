﻿using System;
using System.Collections.Generic;
using System.IO;

namespace MultiMiner.Engine.Configuration
{
    public class EngineConfiguration
    {
        public EngineConfiguration()
        {
            DeviceConfigurations = new List<DeviceConfiguration>();
            CoinConfigurations = new List<CoinConfiguration>();
            MinerConfiguration = new XgminerConfiguration();
        }

        public List<DeviceConfiguration> DeviceConfigurations { get; set; }
        public List<CoinConfiguration> CoinConfigurations { get; set; }
        public XgminerConfiguration MinerConfiguration { get; set; }

        private static string AppDataPath()
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(rootPath, "MultiMiner");
        }

        private static string DeviceConfigurationsFileName()
        {
            return Path.Combine(AppDataPath(), "DeviceConfigurations.xml");
        }
        
        public void SaveDeviceConfigurations()
        {
            ConfigurationReaderWriter.WriteConfiguration(DeviceConfigurations, DeviceConfigurationsFileName());
        }

        public void LoadDeviceConfigurations()
        {
            DeviceConfigurations = ConfigurationReaderWriter.ReadConfiguration<List<DeviceConfiguration>>(DeviceConfigurationsFileName());
        }

        private static string CoinConfigurationsFileName()
        {
            return Path.Combine(AppDataPath(), "CoinConfigurations.xml");
        }

        public void LoadCoinConfigurations()
        {
            CoinConfigurations = ConfigurationReaderWriter.ReadConfiguration<List<CoinConfiguration>>(CoinConfigurationsFileName());
        }

        public void SaveCoinConfigurations()
        {
            ConfigurationReaderWriter.WriteConfiguration(CoinConfigurations, CoinConfigurationsFileName());
        }

        private static string MinerConfigurationFileName()
        {
            return Path.Combine(AppDataPath(), "XgminerConfiguration.xml");
        }

        public void LoadMinerConfiguration()
        {
            MinerConfiguration = ConfigurationReaderWriter.ReadConfiguration<XgminerConfiguration>(MinerConfigurationFileName());
        }

        public void SaveMinerConfiguration()
        {
            ConfigurationReaderWriter.WriteConfiguration(MinerConfiguration, MinerConfigurationFileName());
        }
    }
}
