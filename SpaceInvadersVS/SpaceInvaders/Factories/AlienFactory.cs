using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        private static AlienFactory instance;
        private AlienFactory()
        {
        }
        private void buildAnimators(AlienGrid alien_grid)
        {
            GameSprite a1 =
            GameSpriteManager.find(GameSprite.Name.alien1);
            AnimationSprite anim1 = new AnimationSprite(a1);
            anim1.attachImage(ImageManager.find(ImageNode.Name.alien1_1));
            anim1.attachImage(ImageManager.find(ImageNode.Name.alien1_0));
            TimeManager.add(TimeEvent.Name.animation, Index.INDEX_none, anim1, alien_grid.getStepTime());
            a1 =
            GameSpriteManager.find(GameSprite.Name.alien2);
            anim1 = new AnimationSprite(a1);
            anim1.attachImage(ImageManager.find(ImageNode.Name.alien2_1));
            anim1.attachImage(ImageManager.find(ImageNode.Name.alien2_0));
            TimeManager.add(TimeEvent.Name.animation, Index.INDEX_none, anim1, alien_grid.getStepTime());
            a1 =
            GameSpriteManager.find(GameSprite.Name.alien3);
            anim1 = new AnimationSprite(a1);
            anim1.attachImage(ImageManager.find(ImageNode.Name.alien3_1));
            anim1.attachImage(ImageManager.find(ImageNode.Name.alien3_0));
            TimeManager.add(TimeEvent.Name.animation, Index.INDEX_none, anim1, alien_grid.getStepTime());
        }
        private static AlienFactory getInstance()
        {
            if(instance == null)
            {
                instance = new AlienFactory();
            }
            return instance;
        }
        public static GameObjectCompositeRoot buildAlien(GameObject.Name _goname, Index _index, float _x, float _y)
        {
            AlienFactory inst = getInstance();
            GameSprite.Name spritename = GameSprite.Name.not_initialized;
            // TODO - no!  Bad!
            switch (_goname)
            {
                case GameObject.Name.crab:
                    spritename = GameSprite.Name.alien1;
                    break;
                case GameObject.Name.squid:
                    spritename = GameSprite.Name.alien2;
                    break;
                case GameObject.Name.octopus:
                    spritename = GameSprite.Name.alien3;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            GameSprite gs = GameSpriteManager.find(spritename);
            Debug.Assert(gs != null);
            CollisionObject cs = new CollisionObject(_x, _y, gs.getSize().x, gs.getSize().y, new Azul.Color(1.0f, 0.0f, 0.0f));
            GameSpriteFlyweight a1 = gs.getFlyWeight();
            Debug.Assert(a1 != null);
            a1.getPos().x = _x;
            a1.getPos().y = _y;
            SpriteManager.find(SpriteGroup.Name.aliens).attach(a1);
            GameObject go = new Alien(_goname, _index, a1, cs);
            return go;
        }

        public static GameObjectComposite buildColumn(Index _index, float _x)
        {
            AlienFactory inst = getInstance();
            CollisionObject co = new CollisionObject(0.0f, 0.0f, 0.0f, 0.0f, new Azul.Color(0.0f, 1.0f, 0.0f));
            GameObjectComposite goc = new GameObjectComposite(GameObject.Name.alien_col, co);
            goc.add(buildAlien(GameObject.Name.squid, _index, _x, 825.0f));
            goc.add(buildAlien(GameObject.Name.crab, _index, _x, 760.0f));
            goc.add(buildAlien(GameObject.Name.crab, _index, _x, 695.0f));
            goc.add(buildAlien(GameObject.Name.octopus, _index, _x, 630.0f));
            goc.add(buildAlien(GameObject.Name.octopus, _index, _x, 565.0f));
            return goc;
        }
        public static GameObjectComposite buildGrid()
        {
            AlienFactory inst = getInstance();
            CollisionObject co = new CollisionObject(0.0f, 0.0f, 0.0f, 0.0f, new Azul.Color(0.0f, 0.0f, 1.0f));
            AlienGrid goc = new AlienGrid(co);
            float x = 50.0f;
            for (int i = 0; i < 11; i++)
            {
                goc.add(buildColumn(Index.INDEX_none, x));
                x += 65.0f;
            }
            TimeManager.add(TimeEvent.Name.movement, Index.INDEX_none, new ComAlienMover(goc), goc.getStepTime());
            GameObjectManager.add(goc);
            inst.buildAnimators(goc);
            return goc;
        }
    }
}
