﻿using System;
using Xunit;

namespace Sleddog.Blink1.ExplicitTests
{
    public class Blink1ConnectorTests
    {
        [RequireBlinkHardware]
        public void CanIdentify()
        {
            Assert.DoesNotThrow(() => Blink1Connector.Identify(TimeSpan.FromSeconds(1)));
        }

        [RequireBlinkHardware]
        public void ScanFindsDevices()
        {
            var devices = Blink1Connector.Scan();

            Assert.NotEmpty(devices);
        }

        [RequireNoBlinkHardware]
        public void ScanWithNoDevicesFindsNone()
        {
            var devices = Blink1Connector.Scan();

            Assert.Empty(devices);
        }

        [RequireBlinkHardware]
        public void ConnectToSpecificDevice()
        {
            var serialNumber = "0x20001DDB";

            var device = Blink1Connector.Connect(serialNumber);

            Assert.NotNull(device);
        }
    }
}