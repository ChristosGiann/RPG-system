
public class Character
    {
    public string playerName;
    public int playerLevel;
    public int playerExperiencePoints;
    public int playerHealthPoints;
    public int playerManaPoints;
    public int playerGold;

    public Character(){
        playerName = "";
        playerLevel = 0;
        playerExperiencePoints = 0;
        playerHealthPoints = 0;
        playerManaPoints = 0;
        playerGold = 0;
        }
            
    public void setName(string newplayerName){
        playerName = newplayerName;
        }

    public string getName(){
        return playerName;
        }

     //Levels       
    public void setLevel(int newPlayerLevel){
        playerLevel = newPlayerLevel;
        }

    public int getLevel(){
        return playerLevel;
    }

     //ExperiencePoints
    public void setExperiencePoints(int updatedPlayerExperiencePoints){
        playerExperiencePoints = updatedPlayerExperiencePoints;
        }

    public int getExperiencePoints(){
        return playerExperiencePoints;
        }

    //HealthPoints
    public void setPlayerHealthPoints(int newPlayerHealthPoints){
        playerHealthPoints = newPlayerHealthPoints;
        }

    public int getPlayerHealthPoints(){
        return playerHealthPoints;
        } 

    //ManaPoints
    public void setPlayerManaPoints(int newPlayerManaPoints){
        playerManaPoints = newPlayerManaPoints;
        }

    public int getPlayerManaPoints(){
        return playerManaPoints;
        } 

    //Gold
    public void setPlayerGold(int newPlayerGold){
        playerGold = newPlayerGold;
        }

    public int getPlayerGold(){
        return playerGold;
        } 

    //Methods
    public int levelUp(){
        PlayerLevel += 1;
        return PlayerLevel;
    }



} 
