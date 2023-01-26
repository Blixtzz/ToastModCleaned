using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastModCleaned.Controls;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon.Wrapper.Modules;

namespace ToastModCleaned.QOL
{
    public class Movement : BaseModule
    {
        public static bool clickTP = true;
        public static bool Bhop = true;
        public static bool inf = false;
        public static bool SitOnHead = false;
        public static bool Murder = false;
        private static void ClickTP()
        {
            if (clickTP)
            {
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit))
                {
                    VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point;
                }
            }
        }
        public static void UseLegacyLocomotion()
        {
            VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0.UseLegacyLocomotion();
        }
        public static void ForceJump()
        {
            if (Networking.LocalPlayer.GetJumpImpulse() <= 3)
            {
                Networking.LocalPlayer.SetJumpImpulse(4);
            }
        }
        private static void Jump() 
        {
            Vector3 velocity = Networking.LocalPlayer.GetVelocity();
            velocity.y = Networking.LocalPlayer.GetJumpImpulse();
            Networking.LocalPlayer.SetVelocity(velocity);
            Networking.LocalPlayer.SetJumpImpulse(velocity.y);
        }
        private static void bHop()
        {
            if (Bhop && Networking.LocalPlayer.IsPlayerGrounded())
            {
                Jump();
            }
            if (inf && !Networking.LocalPlayer.IsPlayerGrounded())
            {
                Jump();
            }
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                ClickTP();
            }
            if (VRCInputManager.Method_Public_Static_VRCInput_String_0("Jump").field_Private_Boolean_0)
            {
                bHop();
            }
            if (SitOnHead)
            {
                var target = Wrappers.General.TargetPlayer;
                if (!target)
                    return;
                VRC.Player.prop_Player_0.transform.position = target.field_Private_VRCPlayerApi_0.GetBonePosition(HumanBodyBones.Head) + new Vector3(0, .15f, 0); ;
            }
            if (Murder && Input.GetKeyDown(KeyCode.LeftAlt))
            {
                ApiControls.ForcePickups();
            }
        }
    }
}