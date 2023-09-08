﻿using Game.Level.Weapons.HandlePoints;
using System.Collections.Generic;
using Game.Level.Params.Castles;
using Game.Level.Views.Castles;
using Game.Level.Views.Weapons;
using Game.Common.Interfaces;
using Game.Level.Configs;
using Game.Level.Weapons;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelLifeScope : LifetimeScope, ICoroutineRunner
    {
        [Header("--- Main ---")]
        [SerializeField] private LevelBootstrapper _bootstrapper;
        [SerializeField] private LevelConfig _levelConfig;

        [Header("--- Weapon Params ---")]
        [SerializeField] private Weapon _creationPrefab;
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private WeaponSystemView _weaponSystemView;
        [SerializeField] private List<WeaponHandlePoint> _weaponPlacePoints;

        [Header("--- Castle Params ---")]
        [SerializeField] private DebugCastleParamsProvider _castleParamsProvider;
        [SerializeField] private CastleView _castleView;


        protected override void Configure(IContainerBuilder builder)
        {
            new WeaponSystemInstaller(_creationPrefab, _weaponParent, _weaponSystemView, _weaponPlacePoints)
                .Install(builder);

            new CastleSystemInstaller(_castleParamsProvider, _castleView)
                .Install(builder);

            new LevelSystemInstaller(_bootstrapper, _levelConfig)
                .Install(builder);
        }
    }
}