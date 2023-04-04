// Copyright 2023 Yubico AB
//
// Licensed under the Apache License, Version 2.0 (the "License").
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Yubico.YubiKey.Fido2.Commands;
using Yubico.YubiKey.TestUtilities;
using Xunit;

namespace Yubico.YubiKey.Fido2
{
    public class BioEnrollmentCommandTests : SimpleIntegrationTestConnection
    {
        public BioEnrollmentCommandTests()
            : base(YubiKeyApplication.Fido2, StandardTestDevice.Bio)
        {
        }

        [Fact]
        public void GetModalityCommand_Succeeds()
        {
            var cmd = new GetBioModalityCommand();
            GetBioModalityResponse rsp = Connection.SendCommand(cmd);
            int modality = rsp.GetData();
            
            Assert.Equal(1, modality);
        }

        [Fact]
        public void GetSensorInfoCommand_Succeeds()
        {
            var cmd = new GetFingerprintSensorInfoCommand();
            GetFingerprintSensorInfoResponse rsp = Connection.SendCommand(cmd);
            FingerprintSensorInfo sensorInfo = rsp.GetData();

            Assert.Equal(1, sensorInfo.FingerprintKind);
            Assert.Equal(16, sensorInfo.MaxCaptureCount);
            Assert.Equal(15, sensorInfo.MaxFriendlyNameBytes);
        }
    }
}
