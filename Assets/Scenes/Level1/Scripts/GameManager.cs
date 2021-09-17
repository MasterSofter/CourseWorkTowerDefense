using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using System;

namespace Level1
{
    public class GameManager : MonoBehaviour
    {
        private int _countMaxFinishedEnemies = 5;
        private int _currentCountFinishedEnemies = 0;
        public int CountMaxFinishedEnemies => _countMaxFinishedEnemies;
        public int CurrentCountFinishedEnemies => _currentCountFinishedEnemies;


        public bool BossKilled = false;

        private static GameManager _instance;
        public static GameManager Instance => _instance;

        private List<Enemy> _enemies;
        private List<Enemy> _deletedEnemies;
        public List<Enemy> Enemies => _enemies;

        private List<WarTower> _towers;
        private List<WarTower> _deletedTowers;
        public List<WarTower> Towers => _towers;

        private List<BaseGameObject> _deletedEntities;
        private List<BaseGameObject> _entities;
        public List<BaseGameObject> Entities => _entities;

        private List<BaseGameObject> _deletedButtons;
        private List<BaseGameObject> _buttons;
        public List<BaseGameObject> Buttons => _buttons;

        public TextMeshProUGUI Cost;
        public float fCost;
        


        private int _currentIdEnemy = 0;
        private int _currentIdTower = 0;


        private void Start()
        {
            _instance = this;
            _enemies = new List<Enemy>();
            _towers = new List<WarTower>();
            _deletedEnemies = new List<Enemy>();
            _deletedTowers = new List<WarTower>();

            _entities = new List<BaseGameObject>();
            _deletedEntities = new List<BaseGameObject>();

            _buttons = new List<BaseGameObject>();
            _deletedButtons = new List<BaseGameObject>();

            _countMaxFinishedEnemies = 5;
            _currentCountFinishedEnemies = 0;

            fCost = 100;

        }

        public enum TypeOfEnemy
        {
            Monster = 1,
            MonsterBoss = 2
        }

        public enum TypeOfAmmo
        {
            LaserBullet = 1,
            ColdBullet = 2
        }

        public enum TypeOfButton
        {
            UpgradeTowerButton = 1
        }


        public void SaleTower(int idTower)
        {
            var deletedTower = _towers.FirstOrDefault(i =>
            {
                var c = i.GameObj?.GetComponent<DescriptionTower>();
                return c != null && c.Id == idTower;
            });

            var comp = deletedTower?.GameObj?.GetComponent<DescriptionTower>();

            if (comp != null)
            {
                AddCost(comp.CostSaledTower);
                deletedTower.MoveToState<WarTowerDestroyState>();
            }
        }

        public void UpgradeTower(GameObject gameObjTower, GameObject prefubNewTower)
        {
            WarTower deletedTower = _towers.FirstOrDefault(i => i.GameObj == gameObjTower);

            if (!object.ReferenceEquals(deletedTower, null))
            {
                BuildTower(prefubNewTower, deletedTower.GameObj.transform.position, deletedTower.TypeOfTower, deletedTower.Level + 1);
                deletedTower.MoveToState<WarTowerDestroyState>();
            }
        }


        public void BuildTower(GameObject tower, Vector3 buildPosition, TypeofTowers typeOfTower, int level)
        {
            if (typeOfTower == TypeofTowers.TowerLaser)
            {
                if (level == 1)
                {
                    var towerEmpty = _towers.FirstOrDefault(i => i.GameObj == null);

                    if (towerEmpty == default)
                    {
                        TowerLaser1 towerLaser = new TowerLaser1();

                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);

                        towerLaser.Init(gameObj);
                        Debug.Log(towerLaser.GameObj);
                        
                        towerLaser.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 220;
                        towerLaser.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 80;
                        towerLaser.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        _towers.Add(towerLaser);
                        SubCost(100);
                        _currentIdTower++;
                    }
                    else
                    {
                        towerEmpty = new TowerLaser1();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        towerEmpty.Init(gameObj);
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 220;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 80;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        SubCost(100);
                        _currentIdTower++;
                    }
               
                }
                if (level == 2)
                {
                    var towerEmpty = _towers.FirstOrDefault(i => i.GameObj == null);
                    if (towerEmpty == null)
                    {
                        TowerLaser2 towerLaser = new TowerLaser2();

                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);

                        towerLaser.Init(gameObj);
                        towerLaser.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 350;
                        towerLaser.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 180;
                        towerLaser.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        _towers.Add(towerLaser);
                        SubCost(220);
                        _currentIdTower++;
                    }
                    else
                    {
                        towerEmpty = new TowerLaser2();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        towerEmpty.Init(gameObj);
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 350;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 180;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        SubCost(220);
                        _currentIdTower++;
                    }

                }
                if (level == 3)
                {
                    var towerEmpty = _towers.FirstOrDefault(i => i.GameObj == null);
                    if (towerEmpty == null)
                    {
                        TowerLaser3 towerLaser = new TowerLaser3();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        towerLaser.Init(gameObj);
                        towerLaser.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        towerLaser.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 270;
                        _towers.Add(towerLaser);
                        SubCost(350);
                        _currentIdTower++;
                    }
                    else
                    {
                        towerEmpty = new TowerLaser3();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        towerEmpty.Init(gameObj);
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 270;
                        SubCost(350);
                        _currentIdTower++;
                    }

                }


            }

            if (typeOfTower == TypeofTowers.ColdTower)
            {
                if (level == 1)
                {
                    var towerEmpty = _towers.FirstOrDefault(i => i.GameObj == null);

                    if (towerEmpty == default)
                    {
                        ColdTower1 coldTower = new ColdTower1();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        coldTower.Init(gameObj);
                        coldTower.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 320;
                        coldTower.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 180;
                        coldTower.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        _towers.Add(coldTower);
                        SubCost(250);
                        _currentIdTower++;
                    }
                    else
                    {
                        towerEmpty = new ColdTower1();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        towerEmpty.Init(gameObj);
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 320;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 180;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        SubCost(250);
                        _currentIdTower++;
                    }

                }
                else if (level == 2)
                {
                    var towerEmpty = _towers.FirstOrDefault(i => i.GameObj == null);
                    if (towerEmpty == null)
                    {
                        ColdTower2 coldTower = new ColdTower2();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        coldTower.Init(gameObj);
                        coldTower.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 420;
                        coldTower.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 280;
                        coldTower.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        _towers.Add(coldTower);
                        SubCost(320);
                        _currentIdTower++;
                    }
                    else
                    {
                        towerEmpty = new ColdTower2();
                        GameObject gameObj = Instantiate(tower, buildPosition, Quaternion.identity);
                        towerEmpty.Init(gameObj);
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostUpgrade = 420;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().CostSaledTower = 280;
                        towerEmpty.GameObj.GetComponent<DescriptionTower>().Id = _currentIdTower;
                        SubCost(320);
                        _currentIdTower++;
                    }
                }
            }
        }

        public BaseGameObject CreateAmmo(GameObject prefub, Vector3 position, int typreOfAmmo)
        {
            if (typreOfAmmo == (int)TypeOfAmmo.LaserBullet)
            {
                var ammoEmpty = _entities.FirstOrDefault(i => i.GameObj == null);
                if (ammoEmpty == null)
                {
                    LaserBullet laserBullet = new LaserBullet();
                    GameObject gameObj = Instantiate(prefub, position, Quaternion.identity);

                    laserBullet.Init(gameObj);
                    _entities.Add(laserBullet);
                    return laserBullet;
                }
                else
                {
                    ammoEmpty = new LaserBullet();
                    GameObject gameObj = Instantiate(prefub, position, Quaternion.identity);
                    ammoEmpty.Init(gameObj);
                    return ammoEmpty;
                }
            }
            else if (typreOfAmmo == (int)TypeOfAmmo.ColdBullet)
            {
                var ammoEmpty = _entities.FirstOrDefault(i => i.GameObj == null);
                if (ammoEmpty == null)
                {
                    ColdBullet coldBullet = new ColdBullet();
                    GameObject gameObj = Instantiate(prefub, position, Quaternion.identity);

                    coldBullet.Init(gameObj);
                    _entities.Add(coldBullet);
                    return coldBullet;
                }
                else
                {
                    ammoEmpty = new ColdBullet();
                    GameObject gameObj = Instantiate(prefub, position, Quaternion.identity);
                    ammoEmpty.Init(gameObj);
                    return ammoEmpty;
                }
            }
            else return null;
        }


        public void SpawnEnemy(GameObject enemy, int typeOfEnemy, float health, float speed, float acceleration, bool isBoss = false)
        {
            if (typeOfEnemy == (int)TypeOfEnemy.Monster)
            {
                var enemyEmpty = _enemies.FirstOrDefault(i => i.GameObj == null);
                if (enemyEmpty == null)
                {
                    Monster monster = new Monster();
                    GameObject gameObj = Instantiate(enemy, ResourceManager.Instance.spawnEnemy.transform.position, Quaternion.identity);

                    monster.Init(gameObj);
                    monster.SetHealth(health);
                    monster.SetSpeed(speed);
                    monster.GameObj.GetComponent<EnemyDescription>().speed = speed;
                    monster.SetAcceleration(acceleration);
                    monster.SetTarget(ResourceManager.Instance.targetForEnemy.transform.position);
                    monster.GameObj.GetComponent<EnemyDescription>().Id = _currentIdEnemy;
                    monster.GameObj.GetComponent<EnemyDescription>().fCostDeath = 50;

                    monster.GameObj.GetComponent<EnemyDescription>().IsBoss = isBoss;
    

                    _enemies.Add(monster);
                    _currentIdEnemy++;
                }
                else
                {
                    enemyEmpty = new Monster();
                    GameObject gameObj = Instantiate(enemy, ResourceManager.Instance.spawnEnemy.transform.position, Quaternion.identity);

                    enemyEmpty.Init(gameObj);
                    enemyEmpty.SetHealth(health);
                    enemyEmpty.SetSpeed(speed);
                    enemyEmpty.GameObj.GetComponent<EnemyDescription>().speed = speed;

                    enemyEmpty.SetAcceleration(acceleration);
                    enemyEmpty.SetTarget(ResourceManager.Instance.targetForEnemy.transform.position);
                    enemyEmpty.GameObj.GetComponent<EnemyDescription>().fCostDeath = 50;

                    enemyEmpty.GameObj.GetComponent<EnemyDescription>().IsBoss = isBoss;

                    enemyEmpty.GameObj.GetComponent<EnemyDescription>().Id = _currentIdEnemy;
                    _currentIdEnemy++;
                }
            }

           
            
        }



        public void AddCost(float cost)
        {
            fCost += cost;
            Cost.text = fCost.ToString();

        }

        public void SubCost(float cost)
        {
            fCost -= cost;
            Cost.text = fCost.ToString();
        }


        public void NextWave()
        {
            if (Game.Instance.CurrentWaveId < Game.Instance.CountWaves)
            {
                Game.Instance.CurrentWaveId += 1;
                _enemies.Clear();
                _entities.Clear();
                _deletedTowers.Clear();
            }
                
        }

        private void Update()
        {
            if (Main.Instance.CurrentState is StateRunningGame)
            {
                Cost.text = fCost.ToString();

                var enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
                if (enemies.Count == 0)
                    _enemies.Clear();


                foreach (BaseGameObject it in _entities.Where(i => i.CurrentState != null))
                    it.CurrentState.Do(it);

                foreach (BaseGameObject it in _entities.Where(i=> i.CurrentState is DestroyedBulletState))
                    it.Destroy();

                foreach (Enemy enemy in _enemies.Where(i => i.CurrentState != null))
                    enemy.CurrentState.Do(enemy);


                foreach (Enemy enemy in _enemies.Where(i => i.CurrentState is EnemyDestroyState))
                {
                    if (enemy.Finished)
                        _currentCountFinishedEnemies++;
                    else
                        AddCost(enemy.GameObj.GetComponent<EnemyDescription>().fCostDeath);
                    if (enemy.GameObj.GetComponent<EnemyDescription>().IsBoss == true && !enemy.Finished)
                        BossKilled = true;
                    enemy.Destroy();
                }
                    
        
                    

                foreach (WarTower tower in _towers.Where(i => i.CurrentState != null))
                    tower.CurrentState.Do(tower);

                foreach (WarTower tower in _towers.Where(i => i.CurrentState is WarTowerDestroyState))
                    tower.Destroy();
                    

         
             
                _deletedTowers.Clear();
                _deletedEnemies.Clear();
                _deletedEntities.Clear();
            }
            else
            {
                foreach (Enemy it in _enemies.Where(i => i.GameObj != null))
                    it.GameObj.GetComponent<NavMeshAgent>().enabled = false;
            }
            
        }
    }

    
}


