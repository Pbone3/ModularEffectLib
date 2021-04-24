using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;

namespace ModularEffectLib.Core
{
    public struct CombatEntity
    {
        public enum EntityType
        {
            Error,
            Player,
            NPC,
            Projectile
        }

        public Entity Entity;

        #region Entity Members
        public int whoAmI => Entity.whoAmI;
        public bool active => Entity.active;
        public Vector2 position => Entity.position;
        public Vector2 oldPosition => Entity.oldPosition;
        public Vector2 velocity => Entity.velocity;
        public Vector2 oldVelocity => Entity.oldVelocity;
        public int direction => Entity.direction;
        public int oldDirection => Entity.oldDirection;
        public int width => Entity.width;
        public int height => Entity.height;
        public bool wet => Entity.wet;
        public bool honeyWet => Entity.honeyWet;
        public byte wetCount => Entity.wetCount;
        public bool lavaWet => Entity.lavaWet;

        public Vector2 Center { get => Entity.Center; set => Entity.Center = value; }
        public Vector2 Left { get => Entity.Left; set => Entity.Left = value; }
        public Vector2 Right { get => Entity.Right; set => Entity.Right = value; }
        public Vector2 Top { get => Entity.Top; set => Entity.Top = value; }
        public Vector2 TopLeft { get => Entity.TopLeft; set => Entity.TopLeft = value; }
        public Vector2 TopRight { get => Entity.TopRight; set => Entity.TopRight = value; }
        public Vector2 Bottom { get => Entity.Bottom; set => Entity.Bottom = value; }
        public Vector2 BottomLeft { get => Entity.BottomLeft; set => Entity.BottomLeft = value; }
        public Vector2 BottomRight { get => Entity.BottomRight; set => Entity.BottomRight = value; }
        public Vector2 Size { get => Entity.Size; set => Entity.Size = value; }
        public Rectangle Hitbox { get => Entity.Hitbox; set => Entity.Hitbox = value; }

        public float AngleTo(Vector2 Destination) => (float)Math.Atan2(Destination.Y - Center.Y, Destination.X - Center.X);
        public float AngleFrom(Vector2 Source) => (float)Math.Atan2(Center.Y - Source.Y, Center.X - Source.X);
        public float Distance(Vector2 Other) => Vector2.Distance(Center, Other);
        public float DistanceSQ(Vector2 Other) => Vector2.DistanceSquared(Center, Other);
        public Vector2 DirectionTo(Vector2 Destination) => Vector2.Normalize(Destination - Center);
        public Vector2 DirectionFrom(Vector2 Source) => Vector2.Normalize(Center - Source);
        public bool WithinRange(Vector2 Target, float MaxRange) => Vector2.DistanceSquared(Center, Target) <= MaxRange * MaxRange;
        #endregion

        public bool TryAddBuff(int type, int time, bool quiet = true)
        {
            switch (GetEntityType())
            {
                case EntityType.Player:
                    GetAs<Player>().AddBuff(type, time, quiet);
                    return true;
                case EntityType.NPC:
                    GetAs<NPC>().AddBuff(type, time, quiet);
                    return true;
            }

            return false;
        }

        public bool StrikeIfNPC(int damage, float knockBack, int hitDirection, bool crit = false, bool noEffect = false, bool fromNet = false)
        {
            if (Entity is NPC npc)
            {
                npc.StrikeNPC(damage, knockBack, hitDirection, crit, noEffect, fromNet);
                return true;
            }

            return false;
        }

        public bool StrikeIfPlayer(PlayerDeathReason damageSource, int damage, int hitDirection, bool pvp = true, bool quiet = false, bool Crit = false, int cooldownCounter = -1)
        {
            if (Entity is Player player)
            {
                player.Hurt(damageSource, damage, hitDirection, pvp, quiet, Crit, cooldownCounter);
                return true;
            }

            return false;
        }

        public EntityType GetEntityType()
        {
            if (Entity is Player)
                return EntityType.Player;
            else if (Entity is NPC)
                return EntityType.NPC;
            else if (Entity is Projectile)
                return EntityType.Projectile;

            return EntityType.Error;
        }

        public TEntity GetAs<TEntity>() where TEntity : Entity => Entity as TEntity;
    }
}
