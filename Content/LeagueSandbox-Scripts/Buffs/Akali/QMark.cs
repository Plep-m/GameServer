﻿using System.Numerics;
using GameServerCore.Domain.GameObjects;
using GameServerCore.Domain.GameObjects.Spell;
using GameServerCore.Enums;
using LeagueSandbox.GameServer.API;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Scripting.CSharp;


namespace AkaliMota
{
    class AkaliMota : IBuffGameScript
    {
        public BuffType BuffType => BuffType.COMBAT_DEHANCER;
        public BuffAddType BuffAddType => BuffAddType.REPLACE_EXISTING;
        public int MaxStacks => 1;
        public bool IsHidden => false;

        public IStatsModifier StatsModifier { get; private set; } = new StatsModifier();

        IParticle pbuff;

        public void OnActivate(IAttackableUnit unit, IBuff buff, ISpell ownerSpell)
        {
            pbuff = AddParticleTarget(ownerSpell.CastInfo.Owner, unit, "akali_markOftheAssasin_marker_tar_02.troy", unit, buff.Duration);
            //TODO: Find the overhead particle effects
        }

        public void OnDeactivate(IAttackableUnit unit, IBuff buff, ISpell ownerSpell)
        {
            RemoveParticle(pbuff);
        }

        public void OnPreAttack(ISpell spell)
        {
        }

        public void OnUpdate(float diff)
        {
        }
    }
}