using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BulkMods.Bloons;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkMods.Display.ExampleMonkeyDisplayfldr
{
    internal class ExampleMonkeyDisplay : ModDisplay
    {
        public override string BaseDisplay => GetDisplay("SuperMonkey");

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //2d texture
            //Set2DTexture(node, "ExampleMonkeyDisplay"); // change ExampleMonkeyDisplay with the name of your texture
            
            for(int i = 0; i < node.GetMeshRenderers().Count; i++)
            {
                //node.SaveMeshTexture(i); // this is used to create a template for the 3d displays which can be opened in the mod helper mod and pressing open local files directory
                SetMeshTexture(node, "ExampleMonkeyDisplay" + i, i);
            }
        }
    }

    internal class ExampleProjectileDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "ExampleProjectileDisplay"); //Change "ExampleProjectileDisplay" With the name of your texture
        }
    }

    
}
