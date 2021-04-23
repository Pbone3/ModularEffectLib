using static ModularEffectLib.Core.EventSystem.Delegates;

namespace ModularEffectLib.Core.EventSystem
{
    internal class ItemEffectEventPool
    {
        #region ModPlayer
        internal EventContainer<CanBeHitByNPC> CanBeHitByNPC;
        internal EventContainer<CanBeHitByProjectile> CanBeHitByProjectile;
        internal EventContainer<CanBuyItem> CanBuyItem;
        internal EventContainer<CanHitPvp> CanHitPvp;
        internal EventContainer<CanHitPvpWithProj> CanHitPvpWithProj;
        internal EventContainer<CanSellItem> CanSellItem;
        internal EventContainer<ConsumeAmmo> ConsumeAmmo;
        internal EventContainer<ModifyNurseHeal> ModifyNurseHeal;
        internal EventContainer<PreHurt> PreHurt;
        internal EventContainer<PreItemCheck> PreItemCheck;
        internal EventContainer<PreKill> PreKill;
        internal EventContainer<ShiftClickSlot> ShiftClickSlot;
        internal EventContainer<Shoot> Shoot;
        internal EventContainer<CanHitNPC> CanHitNPC;
        internal EventContainer<CanHitNPCWithProj> CanHitNPCWithProj;
        internal EventContainer<MeleeSpeedMultiplier> MeleeSpeedMultiplier;
        internal EventContainer<UseTimeMultiplier> UseTimeMultiplier;
        internal EventContainer<Save> Save;
        internal EventContainer<AnglerQuestReward> AnglerQuestReward;
        internal EventContainer<CatchFish> CatchFish;
        internal EventContainer<clientClone> clientClone;
        internal EventContainer<DrawEffects> DrawEffects;
        internal EventContainer<FrameEffects> FrameEffects;
        internal EventContainer<GetDyeTraderReward> GetDyeTraderReward;
        internal EventContainer<GetFishingLevel> GetFishingLevel;
        internal EventContainer<GetHealLife> GetHealLife;
        internal EventContainer<GetHealMana> GetHealMana;
        internal EventContainer<GetWeaponCrit> GetWeaponCrit;
        internal EventContainer<GetWeaponKnockback> GetWeaponKnockback;
        internal EventContainer<Hurt> Hurt;
        internal EventContainer<Initialize> Initialize;
        internal EventContainer<Kill> Kill;
        internal EventContainer<Load> Load;
        internal EventContainer<LoadLegacy> LoadLegacy;
        internal EventContainer<MeleeEffects> MeleeEffects;
        internal EventContainer<ModifyDrawHeadLayers> ModifyDrawHeadLayers;
        internal EventContainer<ModifyDrawInfo> ModifyDrawInfo;
        internal EventContainer<ModifyDrawLayers> ModifyDrawLayers;
        internal EventContainer<ModifyHitByNPC> ModifyHitByNPC;
        internal EventContainer<ModifyHitByProjectile> ModifyHitByProjectile;
        internal EventContainer<ModifyHitNPC> ModifyHitNPC;
        internal EventContainer<ModifyHitNPCWithProj> ModifyHitNPCWithProj;
        internal EventContainer<ModifyHitPvp> ModifyHitPvp;
        internal EventContainer<ModifyHitPvpWithProj> ModifyHitPvpWithProj;
        internal EventContainer<ModifyManaCost> ModifyManaCost;
        internal EventContainer<ModifyNursePrice> ModifyNursePrice;
        internal EventContainer<ModifyScreenPosition> ModifyScreenPosition;
        internal EventContainer<ModifyWeaponDamage> ModifyWeaponDamage;
        internal EventContainer<ModifyZoom> ModifyZoom;
        internal EventContainer<NaturalLifeRegen> NaturalLifeRegen;
        internal EventContainer<OnConsumeAmmo> OnConsumeAmmo;
        internal EventContainer<OnConsumeMana> OnConsumeMana;
        internal EventContainer<OnEnterWorld> OnEnterWorld;
        internal EventContainer<OnHitAnything> OnHitAnything;
        internal EventContainer<OnHitByNPC> OnHitByNPC;
        internal EventContainer<OnHitByProjectile> OnHitByProjectile;
        internal EventContainer<OnHitNPC> OnHitNPC;
        internal EventContainer<OnHitNPCWithProj> OnHitNPCWithProj;
        internal EventContainer<OnHitPvp> OnHitPvp;
        internal EventContainer<OnHitPvpWithProj> OnHitPvpWithProj;
        internal EventContainer<OnMissingMana> OnMissingMana;
        internal EventContainer<OnRespawn> OnRespawn;
        internal EventContainer<PlayerConnect> PlayerConnect;
        internal EventContainer<PlayerDisconnect> PlayerDisconnect;
        internal EventContainer<PostBuyItem> PostBuyItem;
        internal EventContainer<PostHurt> PostHurt;
        internal EventContainer<PostItemCheck> PostItemCheck;
        internal EventContainer<PostNurseHeal> PostNurseHeal;
        internal EventContainer<PostSavePlayer> PostSavePlayer;
        internal EventContainer<PostSellItem> PostSellItem;
        internal EventContainer<PostUpdate> PostUpdate;
        internal EventContainer<PostUpdateBuffs> PostUpdateBuffs;
        internal EventContainer<PostUpdateEquips> PostUpdateEquips;
        internal EventContainer<PostUpdateMiscEffects> PostUpdateMiscEffects;
        internal EventContainer<PostUpdateRunSpeeds> PostUpdateRunSpeeds;
        internal EventContainer<PreSaveCustomData> PreSaveCustomData;
        internal EventContainer<PreSavePlayer> PreSavePlayer;
        internal EventContainer<PreUpdate> PreUpdate;
        internal EventContainer<PreUpdateBuffs> PreUpdateBuffs;
        internal EventContainer<PreUpdateMovement> PreUpdateMovement;
        internal EventContainer<ProcessTriggers> ProcessTriggers;
        internal EventContainer<ResetEffects> ResetEffects;
        internal EventContainer<SendClientChanges> SendClientChanges;
        internal EventContainer<SetControls> SetControls;
        internal EventContainer<SetupStartInventory> SetupStartInventory;
        internal EventContainer<SyncPlayer> SyncPlayer;
        internal EventContainer<UpdateAutopause> UpdateAutopause;
        internal EventContainer<UpdateBadLifeRegen> UpdateBadLifeRegen;
        internal EventContainer<UpdateBiomes> UpdateBiomes;
        internal EventContainer<UpdateBiomeVisuals> UpdateBiomeVisuals;
        internal EventContainer<UpdateDead> UpdateDead;
        internal EventContainer<UpdateEquips> UpdateEquips;
        internal EventContainer<UpdateLifeRegen> UpdateLifeRegen;
        internal EventContainer<UpdateVanityAccessories> UpdateVanityAccessories;
        #endregion

        internal void Register(ItemEffect effect)
        {
        }
    }
}
