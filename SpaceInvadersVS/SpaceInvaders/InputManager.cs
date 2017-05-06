using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputManager
    {
        private bool left, right, shoot, shoot_key, shoot_key_prev;
        private bool key1, key1_prev, key1_down;
        private bool key2, key2_prev, key2_down;
        private bool key3, key3_prev, key3_down;
        public InputManager() 
        {
            left = right = shoot = false;
            key1 = key1_prev = key1_down = false;
            key2 = key2_prev = key2_down = false;
            key3 = key3_prev = key3_down = false;
        }
        public static void keyboardInputs()
        {
            InputManager inst = SceneManager.getInputManager();
            inst.right = Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_RIGHT);
            inst.left = Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_LEFT);
            inst.shoot_key = Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_SPACE);
            inst.shoot = inst.shoot_key && !inst.shoot_key_prev;
            inst.shoot_key_prev = inst.shoot_key;
            inst.key1_down = Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_1);
            inst.key1 = inst.key1_down && !inst.key1_prev;
            inst.key1_prev = inst.key1_down;
            inst.key2_down = Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_2);
            inst.key2 = inst.key2_down && !inst.key2_prev;
            inst.key2_prev = inst.key2_down;
            inst.key3_down = Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_3);
            inst.key3 = inst.key3_down && !inst.key3_prev;
            inst.key3_prev = inst.key3_down;

            inst.processInputs();
        }
        private void processInputs()
        {
            GameObjectCompositeRoot pGameObj = GameObjectManager.find(GameObject.Name.player);
            if (this.right && pGameObj != null)
            {
                pGameObj.move(10.0f, 0.0f);
            }
            if (this.left && pGameObj != null)
            {
                pGameObj.move(-10.0f, 0.0f);
            }
            if (this.shoot && pGameObj != null)
            {
                ((Player)pGameObj).spawnBullet();
            }

            if (this.key1)
            {
                Scene pScene = SceneManager.getActiveScene();
                //TODO
                if (pScene is AttractScene)
                {
                    ((AttractScene)pScene).selectNumPlayers(1);
                }
            }
            if (this.key2)
            {
                Scene pScene = SceneManager.getActiveScene();
                //TODO
                if (pScene is AttractScene)
                {
                    ((AttractScene)pScene).selectNumPlayers(2);
                }
            }
            if (this.key3)
            {
                SceneManager.getActiveScene().toggleBoundingBoxes();
            }
        }
    }
}
