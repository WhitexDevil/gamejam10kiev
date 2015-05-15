﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CatapultGame
{
    using Step = KeyValuePair<Point, float>;
    public class Offensive : Strategy
    {
        static void Surround(BattleData battleData)
        {
            if (battleData.EnemyArmy.Length < 1)
                return;

            for (int i = 0; i < battleData.AllyArmy.Length; i++)
            {
                int TargetIndex = Strategy.NearestToAll(battleData.AllyArmy, battleData.EnemyArmy);
                if (TargetIndex < 0)
                    return;
                Step[] Path = DistanceAndPath.PathTo(
                    battleData,
                    battleData.AllyArmy[i].Position,
                    battleData.EnemyArmy[TargetIndex].Position,
                    battleData.AllyArmy[i].Unit.Range);

                Strategy.MoveAndAttack(battleData.AllyArmy[i], battleData.EnemyArmy[TargetIndex], Path, battleData);
            }

        }
        static void Rush(BattleData battleData)
        {
            if (battleData.EnemyArmy.Length < 1)
                return;
            for (int i = 0; i < battleData.AllyArmy.Length; i++)
            {
                int TargetIndex = Strategy.NearestToPoint(battleData.AllyArmy[i].Position, battleData.EnemyArmy);
                if (TargetIndex < 0)
                    return;
                Step[] Path = DistanceAndPath.PathTo(
                    battleData,
                    battleData.AllyArmy[i].Position,
                    battleData.EnemyArmy[TargetIndex].Position,
                    battleData.AllyArmy[i].Unit.Range);

                Strategy.MoveAndAttack(battleData.AllyArmy[i], battleData.EnemyArmy[TargetIndex], Path, battleData);


            }
        }
        public Offensive()
        {

            Maneuvers[0] = Surround;
            Maneuvers[1] = Rush;
        }
    }
}
