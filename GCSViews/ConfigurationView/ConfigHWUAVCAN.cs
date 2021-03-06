﻿using System;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigHWUAVCAN : UserControl, IActivate
    {
        private const double rad2deg = (float) (180/Math.PI);
        private const double deg2rad = (float) (1.0/rad2deg);

        public ConfigHWUAVCAN()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
            {
                Enabled = false;
            }
            Enabled = true;

            mavlinkComboBox_uavcan.setup(ParameterMetaDataRepository.GetParameterOptionsInt("BRD_CAN_ENABLE",
                MainV2.comPort.MAV.cs.firmware.ToString()), "BRD_CAN_ENABLE", MainV2.comPort.MAV.param);
        }


        private void but_startenum_Click(object sender, EventArgs e)
        {
            MainV2.comPort.doCommand(MAVLink.MAV_CMD.PREFLIGHT_UAVCAN, 1, 0, 0, 0, 0, 0, 0, false);
        }

        private void but_stopenum_Click(object sender, EventArgs e)
        {
            MainV2.comPort.doCommand(MAVLink.MAV_CMD.PREFLIGHT_UAVCAN, 0, 0, 0, 0, 0, 0, 0, false);
        }

        private void but_saveconfig_Click(object sender, EventArgs e)
        {
            MainV2.comPort.doCommand(MAVLink.MAV_CMD.PREFLIGHT_STORAGE, 1, 0, 0, 0, 0, 0, 0, false);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            but_factoryreset.Enabled = checkBox1.Checked;
        }

        private void but_factoryreset_Click(object sender, EventArgs e)
        {
            MainV2.comPort.doCommand(MAVLink.MAV_CMD.PREFLIGHT_STORAGE, 2, 0, 0, 0, 0, 0, 0, false);
        }

        private void mavlinkComboBox_uavcan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}