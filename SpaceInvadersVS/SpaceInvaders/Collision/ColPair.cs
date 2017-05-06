using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColPair : LinkNode
    {
        public enum Name
        {
            alien_bullet,
            alien_shield,
            alien_player,
            alien_rwall,
            alien_lwall,
            player_bomb,
            player_lwall,
            player_rwall,
            bullet_ufo,
            bullet_shield,
            bullet_ceiling,
            bomb_shield,
            bomb_floor,
            not_initialized
        }
        private GameObjectCompositeRoot goList1, goList2;
        private CollisionSubject pColSubj;
        private ColPair.Name name;
        private Index index;
        public ColPair()
            : base()
        {
            name = ColPair.Name.not_initialized;
            index = Index.INDEX_none;
            pColSubj = new CollisionSubject();
        }
        public override void clear()
        {
            goList1 = goList2 = null;
            pColSubj.clear();
            name = ColPair.Name.not_initialized;
            index = Index.INDEX_none;
        }
        public override Enum getName()
        {
            return this.name;
        }
        public override Enum getIndex()
        {
            return this.index;
        }
        public void initialize(ColPair.Name _name, Index _index, GameObjectCompositeRoot _goList1, GameObjectCompositeRoot _goList2)
        {
            Debug.Assert(_goList1 != null);
            Debug.Assert(_goList2 != null);
            this.name = _name;
            this.index = _index;
            this.goList1 = _goList1;
            this.goList2 = _goList2;
        }
        public GameObjectCompositeRoot getList1()
        {
            return this.goList1;
        }
        public GameObjectCompositeRoot getList2()
        {
            return this.goList2;
        }
        public void attachObserver(CollisionObserver _colObs)
        {
            pColSubj.attachObserver(_colObs);
        }
        public void notifyObservers(GameObjectCompositeRoot gobj1, GameObjectCompositeRoot gobj2)
        {
            pColSubj.notifyObservers(gobj1, gobj2);
        }
        public void process()
        {
            if (this.goList1 != null && this.goList2 != null)
            {
                Rect r1 = this.goList1.getBoundingVol();
                Rect r2 = this.goList2.getBoundingVol();
                if (r1.intersects(r2))
                {
                    this.goList1.accept(this.goList2);
                }
            }
        }
        public void remove(GameObjectCompositeRoot _goc)
        {
            if (goList1.Equals(_goc))
            {
                goList1 = null;
            }
            if (goList2.Equals(_goc))
            {
                goList2 = null;
            }
        }
    }
}
