﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnuBattleRods.Projectiles.Bobbers.NormalMode
{
    public class MeteorBobber : Bobber
    {

        public override void SetDefaults()
        {
            base.SetDefaults();
            timeBobMax = 120;
            timeReelMax = 40;
            sizeMultiplier = 2.5f;
            speedIncrease = 3.0f;
        }

        public override float TensileStrength()
        {
            return 65f;
        }

        public override void alterCenter(float gravDir, ref float x, ref float y)
        {
            x += (float)(43 * Main.player[base.projectile.owner].direction);
            if (Main.player[base.projectile.owner].direction < 0)
            {
               x -= 13f;
            }
            y -= 31f * gravDir;
        }

        public override Color getLineColor(Vector2 value)
        {
            return Lighting.GetColor((int)value.X / 16, (int)(value.Y / 16f), new Color(200, 200, 200, 100));
        }


        public override void PostAI()
        {
            Lighting.AddLight(projectile.Center, 1.0f, 1.0f, 0.0f);
        }


        public override void applyDamageAndDebuffs(NPC npc, Player player)
        {
            base.applyDamageAndDebuffs(npc, player);
            if (!npc.buffImmune[BuffID.OnFire])
            {
                npc.AddBuff(BuffID.OnFire, 60);
            }
            
        }

        public override void applyDamageAndDebuffs(Player target, Player player)
        {
            base.applyDamageAndDebuffs(target, player);
            if (!player.buffImmune[BuffID.OnFire])
            {
                player.AddBuff(BuffID.OnFire, 60);
            }
        }
    }
}