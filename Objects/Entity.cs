using GameCharacter;
using GameInventory;
using GameWeapon;

namespace GameEntity{
    class Entity : Inventory{
        public string name {get; private set;}
        public int maxhealth{get; private set;}
        public int health {get; private set;}
        public string description {get; private set;}
        public bool breakable {get;private set;}
        public int damage {get;private set;}
        protected Inventory inventory {get;set;}
        
        public void Inventory(Entity entity) => base.Add(entity);
        public void Inventory() => base.CheckInventory();
        protected Entity(string name, int health, string description, bool breakable, bool hasInventory, int damage): base(){
            this.name = name;
            this.health = health;
            this.description = description;
            this.breakable = breakable;
            this.damage = damage; 
        }
        public void GiveName(string name){
            this.name = name;
        }
        public void Health(int value){
            this.health = this.health + value >= this.maxhealth ? this.maxhealth : 
                (this.health + value <= 0 ? 0 : this.health + value);
        }
        public void SetHealth(int value){
            if((value) >= this.maxhealth){
                this.health = this.maxhealth;
            }else if(value <= 0 || (value == 1 && this.health ==1)){
                this.health = 0;
            }else{
                this.health = value;
            }
        }
        public void MaxHealth(int value){
            if((this.maxhealth + value)<= 1){
                this.maxhealth = 1;
            }else{
                this.maxhealth += value;
            }
            if(this.maxhealth<this.health){
                this.health = this.maxhealth;
            }
        }
        public void SetMaxHealth(int value){
            if(value <= 1){
                this.maxhealth = 1;
            }else{
                this.maxhealth = value;
            }
            if(this.health < this.maxhealth){
                this.health = this.maxhealth;
            }
        }
        public void Interact(Entity entityOne, Entity entityTwo){
            if((entityOne is Character)){

            }
        }
        protected void Primary(Entity entity) => base.EquipPrimary(entity);
        protected void Secondary(Entity entity) => base.EquipSecondary(entity);
        //Throwable enitites, could be weapons, potions, etc.. 

    }
}