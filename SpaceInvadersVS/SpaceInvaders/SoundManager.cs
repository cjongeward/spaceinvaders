using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class soundNode
    {
        public soundNode next;
        public String sound;
        public soundNode(String a)
        {
            sound = a;
        }
        public void play()
        {
            Azul.Audio.playSound(sound, false, false, true);
        }
    }
    class SoundManager
    {
        private static SoundManager instance;
        private soundNode march;
        private soundNode shoot;
        private soundNode alienEx;
        private soundNode playerEx;
        private SoundManager()
        {
            march = new soundNode("A.wav");
            march.next = new soundNode("B.wav");
            march.next.next = new soundNode("C.wav");
            march.next.next.next = new soundNode("D.wav");
            march.next.next.next.next = march;
            shoot = new soundNode("invaderkilled.wav");
            alienEx = new soundNode("shoot.wav");
            playerEx = new soundNode("explosion.wav");

        }
        private static SoundManager getInstance()
        {
            if(instance == null)
            {
                instance = new SoundManager();
            }
            return instance;
        }
        public static void playMarch()
        {
            SoundManager inst = getInstance();
            inst.march.play();
            inst.march = inst.march.next;
        }
        public static void playShoot()
        {
            SoundManager inst = getInstance();
            inst.shoot.play();
        }
        public static void playAlienEx()
        {
            SoundManager inst = getInstance();
            inst.alienEx.play();
        }
        public static void playPlayerEx()
        {
            SoundManager inst = getInstance();
            inst.playerEx.play();
        }
    }
}
