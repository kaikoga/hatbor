using Hatbor.VMC;
using UnityEngine;
using VContainer;

namespace Hatbor.Rig.VMC
{
    public sealed class VmcCameraRig : ICameraRig
    {
        readonly VmcServer vmcServer;

        [Inject]
        public VmcCameraRig(VmcServer vmcServer)
        {
            this.vmcServer = vmcServer;
        }

        void ICameraRig.Update(Camera camera)
        {
            vmcServer.ProcessRead();

            var cameraPose = vmcServer.CameraPose;
            var cameraFov = vmcServer.CameraFov;
            var cameraTransform = camera.transform;
            cameraTransform.position = cameraPose.position;
            cameraTransform.rotation = cameraPose.rotation;
            camera.fieldOfView = cameraFov;
        }
    }
}