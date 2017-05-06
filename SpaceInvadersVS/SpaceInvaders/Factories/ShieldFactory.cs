using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        private static ShieldFactory instance;
        private ShieldFactory()
        {
        }
        private static ShieldFactory getInstance()
        {
            if(instance == null)
            {
                instance = new ShieldFactory();
            }
            return instance;
        }
        private GameObjectCompositeRoot BuildShieldChunk(GameSprite.Name _goname, float _x, float _y)
        {
            GameSprite gs = GameSpriteManager.find(_goname);
            CollisionObject gs_co = new CollisionObject(350.0f, 100.0f, gs.getSize().x, gs.getSize().y, new Azul.Color(0.5f, 0.5f, 1.0f));
            GameSpriteFlyweight gs_fw = gs.getFlyWeight();
            gs_fw.setPos(new Vector2(_x, _y));
            SpriteManager.find(SpriteGroup.Name.shields).attach(gs_fw);
            GameObjectCompositeRoot shield = new ShieldChunk(GameObject.Name.shield_chunk, Index.INDEX_none, gs_fw, gs_co);
            return shield;
        }
        private GameObjectCompositeRoot BuildShield(float _x, float _y)
        {
            float tilew = 20.0f;
            float tileh = 20.0f;
            CollisionObject co = new CollisionObject(0.0f, 0.0f, 0.0f, 0.0f, new Azul.Color(0.5f, 0.5f, 1.0f));
            GameObjectComposite goc = new GameObjectComposite(GameObject.Name.shield, co);
            goc.add(BuildShieldChunk(GameSprite.Name.shieldtl, _x + 1 * tilew, _y + 6 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 2 * tilew, _y + 6 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 3 * tilew, _y + 6 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 4 * tilew, _y + 6 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shieldtr, _x + 5 * tilew, _y + 6 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shieldtl, _x + 0 * tilew, _y + 5 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 1 * tilew, _y + 5 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 2 * tilew, _y + 5 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 3 * tilew, _y + 5 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 4 * tilew, _y + 5 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 5 * tilew, _y + 5 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shieldtr, _x + 6 * tilew, _y + 5 * tileh));
            for (int i = 0; i < 7; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + i * tilew, _y + j * tileh));
                }
            }
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 0 * tilew, _y + 1 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 1 * tilew, _y + 1 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shieldbr, _x + 2 * tilew, _y + 1 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shieldbl, _x + 4 * tilew, _y + 1 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 5 * tilew, _y + 1 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 6 * tilew, _y + 1 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 0 * tilew, _y + 0 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 1 * tilew, _y + 0 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 5 * tilew, _y + 0 * tileh));
            goc.add(BuildShieldChunk(GameSprite.Name.shield, _x + 6 * tilew, _y + 0 * tileh));
            return goc;
        }
        public static GameObjectCompositeRoot BuildShieldGroup()
        {
            ShieldFactory inst = getInstance();
            CollisionObject co = new CollisionObject(0.0f, 0.0f, 0.0f, 0.0f, new Azul.Color(0.0f, 0.0f, 1.0f));
            GameObjectComposite goc = new GameObjectComposite(GameObject.Name.shield_group, co);
            goc.add(inst.BuildShield(75.0f, 200.0f));
            goc.add(inst.BuildShield(275.0f, 200.0f));
            goc.add(inst.BuildShield(475.0f, 200.0f));
            goc.add(inst.BuildShield(675.0f, 200.0f));
            return goc;
        }
    }
}
