using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Framework;
using UnityEngine.UI;
using TMPro;
public enum QUESSTION_STATUS
{
    SELECT_ALL_THE_SAME_PICTURES = 0 ,//chọn ra tất cả các hình giống nhau
    NOT_SAME_ALL_PICTURES = 1,// chọn hình không giống với tất cả các hình còn lại
    PICK_UP_DIRECTION = 2,//chọn hình hướng lên
    PICK_DOWN_DIRECTION = 3,//chọn hình hướng xuống 
    PICK_LEFT_DIRECTION = 4,//chọn hình hướng sang trái
    PICK_RIGHT_DIRECTION = 5,//chọn hình hướng sang phải
    ALL_SHAPES_WITH_THE_SAME_ORIENTION = 6,// tất cả các hình cùng hướng với nhau
    PICTURE_DIFFERENT_ORIENTATION_ALL_THE_OTHERS = 7,//khác hướng với tất cả các hình còn lại
    SELECT_A_PICTURE_NAME_IN_THE_ALL_PICTURE = 8,//chọn ra tên một đối tượng trong tất cả các ảnh;
}
public enum GROUP_PICTURES_STATUS
{
    ANIMALS_GROUP = 0,
    FRUITS_GROUP = 1,
    GEOMETRYS_GROUP = 2,
    HOME_APPLIANCES_GROUP = 3,
    INSECTS_GROUP = 4,
    LEARNING_TOOLS_GROUP = 5,
    MEAN_OF_TRANSPORTATION_GROUP = 6,
    VEGETABLES_GROUP = 7,
}
public enum GROUP_PICTURES_DIRECTION_STATUS
{
    TREES_GROUP = 0,
    WORLD_WONDER_GROUP = 1,
}
public enum DIRECTION_STATUS
{
    NO_STATUS = 0,
    UP = 1,
    DOWN = 2,
    LEFT = 3,
    RIGHT = 4,
}

public class ShapeClassification_InitQuesstion : MonoBehaviour
{

    private int currentQuestion;
    private int randomQuestion;
    private List<Questions> questionsList;
    private List<RotatedSprite> iconList = new List<RotatedSprite>();
    private List<Sprite> initIconList = new List<Sprite>();
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private TextMeshProUGUI showQuestion;
    [SerializeField] private GameObject PosOriginIcon;
    [SerializeField] private GameObject showIconGroup;
    private void Start()
    {
        currentQuestion = 1;
        questionsList = new List<Questions>();
        QUESSTION_STATUS randomQuestion = GetRandomQuestionStatus();
        InitQuestionStart(randomQuestion);
    }
    //lấy ngẫu nhiên câu hỏi
    private  QUESSTION_STATUS GetRandomQuestionStatus()
    {
        System.Random random = new System.Random();
        Array values = Enum.GetValues(typeof(QUESSTION_STATUS));
        return (QUESSTION_STATUS)values.GetValue(random.Next(values.Length));
    }
    //lấy ngẫu nhiên phương hướng của các game obiect
    private DIRECTION_STATUS GetRandomDirectionStatus(DIRECTION_STATUS correctDirection)
    {
        System.Random random = new System.Random();
        if(correctDirection == DIRECTION_STATUS.UP)
        {
            DIRECTION_STATUS[] allowedStatuses = { DIRECTION_STATUS.DOWN, DIRECTION_STATUS.LEFT, DIRECTION_STATUS.RIGHT };
            int randomIndex = random.Next(allowedStatuses.Length);
            return allowedStatuses[randomIndex];
        }
        else if(correctDirection == DIRECTION_STATUS.DOWN)
        {
            DIRECTION_STATUS[] allowedStatuses = { DIRECTION_STATUS.UP, DIRECTION_STATUS.LEFT, DIRECTION_STATUS.RIGHT };
            int randomIndex = random.Next(allowedStatuses.Length);
            return allowedStatuses[randomIndex];
        }
        else if(correctDirection == DIRECTION_STATUS.LEFT)
        {
            DIRECTION_STATUS[] allowedStatuses = { DIRECTION_STATUS.DOWN, DIRECTION_STATUS.UP, DIRECTION_STATUS.RIGHT };
            int randomIndex = random.Next(allowedStatuses.Length);
            return allowedStatuses[randomIndex];
        }
        else if(correctDirection == DIRECTION_STATUS.RIGHT)
        {
            DIRECTION_STATUS[] allowedStatuses = { DIRECTION_STATUS.DOWN, DIRECTION_STATUS.LEFT, DIRECTION_STATUS.UP };
            int randomIndex = random.Next(allowedStatuses.Length);
            return allowedStatuses[randomIndex];
        }
        else
        {
            DIRECTION_STATUS[] allowedStatuses = { DIRECTION_STATUS.DOWN, DIRECTION_STATUS.LEFT, DIRECTION_STATUS.UP, DIRECTION_STATUS.RIGHT};
            int randomIndex = random.Next(allowedStatuses.Length);
            return allowedStatuses[randomIndex];
        }
    }
    //khởi tạo phương thức quản lý câu hỏi 
    private void InitQuestionStart(QUESSTION_STATUS randomQuestion)
    {
        questionsList = new List<Questions>();
        if (randomQuestion == QUESSTION_STATUS.SELECT_ALL_THE_SAME_PICTURES)
        {
            Debug.Log("khoi tao" + randomQuestion);
            int randomCorrectAnswerIndex = UnityEngine.Random.Range(1, 4);
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(1, 4);
            QuestionText questionText = new QuestionText();
            InitQuestion_Alike_Ulike(questionText.SelectAllTheSamePictures, randomCorrectAnswerIndex, randomWrongtAnswerIndex, randomQuestion);
        }
        else if (randomQuestion == QUESSTION_STATUS.NOT_SAME_ALL_PICTURES)
        {
            Debug.Log("khoi tao" + randomQuestion);
            int randomCorrectAnswerIndex = UnityEngine.Random.Range(1, 4);
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(1, 4);
            QuestionText questionText = new QuestionText();
            InitQuestion_Alike_Ulike(questionText.SelectAllTheSamePictures, randomCorrectAnswerIndex, randomWrongtAnswerIndex, randomQuestion);
        }
        else if (randomQuestion == QUESSTION_STATUS.PICK_UP_DIRECTION)
        {
            int randomCorrectAnswerIndex = UnityEngine.Random.Range(1, 4);
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(1, 4);
            Debug.Log("khoi tao" + randomQuestion);
            QuestionText questionText = new QuestionText();
            InitQuestion_setDirection(questionText.PickUpDirection, DIRECTION_STATUS.UP, randomQuestion, randomCorrectAnswerIndex, randomWrongtAnswerIndex);
        }
        else if (randomQuestion == QUESSTION_STATUS.PICK_DOWN_DIRECTION)
        {
            int randomCorrectAnswerIndex = UnityEngine.Random.Range(1, 4);
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(1, 4);
            Debug.Log("khoi tao" + randomQuestion);
            QuestionText questionText = new QuestionText();
            InitQuestion_setDirection(questionText.PickDownDirection, DIRECTION_STATUS.DOWN, randomQuestion, randomCorrectAnswerIndex, randomWrongtAnswerIndex);
        }
        else if (randomQuestion == QUESSTION_STATUS.PICK_LEFT_DIRECTION)
        {
            int randomCorrectAnswerIndex = UnityEngine.Random.Range(1, 4);
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(1, 4);
            Debug.Log("khoi tao" + randomQuestion);
            QuestionText questionText = new QuestionText();
            InitQuestion_setDirection(questionText.PickLeftDirection, DIRECTION_STATUS.LEFT, randomQuestion, randomCorrectAnswerIndex, randomWrongtAnswerIndex);
        }
        else if (randomQuestion == QUESSTION_STATUS.PICK_RIGHT_DIRECTION)
        {
            int randomCorrectAnswerIndex = UnityEngine.Random.Range(1, 4);
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(1, 4);
            Debug.Log("khoi tao" + randomQuestion);
            QuestionText questionText = new QuestionText();
            InitQuestion_setDirection(questionText.PickRightDirection, DIRECTION_STATUS.RIGHT, randomQuestion, randomCorrectAnswerIndex, randomWrongtAnswerIndex);
        }
        else if (randomQuestion == QUESSTION_STATUS.ALL_SHAPES_WITH_THE_SAME_ORIENTION)
        {
            int randomCorrectAnswerIndex = UnityEngine.Random.Range(2, 15);
            int randomWrongtAnswerIndex = 1;
            Debug.Log("khoi tao" + randomQuestion);
            QuestionText questionText = new QuestionText();
            DIRECTION_STATUS correctDirection = GetRandomDirectionStatus(DIRECTION_STATUS.NO_STATUS);
            InitQuestion_setDirection(questionText.AllShapesWithTheSameOriention, correctDirection, randomQuestion, randomCorrectAnswerIndex, randomWrongtAnswerIndex);
        }
        else if (randomQuestion == QUESSTION_STATUS.PICTURE_DIFFERENT_ORIENTATION_ALL_THE_OTHERS)
        {
            int randomCorrectAnswerIndex = 1;
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(1, 7);
            Debug.Log("khoi tao" + randomQuestion);
            QuestionText questionText = new QuestionText();
            DIRECTION_STATUS correctDirection = GetRandomDirectionStatus(DIRECTION_STATUS.NO_STATUS);
            InitQuestion_setDirection(questionText.DirectionDifferentWithAllPictures, correctDirection, randomQuestion, randomCorrectAnswerIndex, randomWrongtAnswerIndex);
        }
        else if(randomQuestion == QUESSTION_STATUS.SELECT_A_PICTURE_NAME_IN_THE_ALL_PICTURE)
        {
            int randomCorrectAnswerIndex = 1;
            int randomWrongtAnswerIndex = UnityEngine.Random.Range(4, 12);
            QuestionText questionText = new QuestionText();
            InitQuestion_Alike_Ulike(questionText.SelectAPictureNameInTheAllPicture, randomCorrectAnswerIndex, randomWrongtAnswerIndex, randomQuestion);
        }
    }
    //lấy ngẫu nhiên các hình đúng trong list sprite
    public static List<Sprite> GetRandomElementsCorect<Sprite>(List<Sprite> list, int count)
    {
        if(count > list.Count)
        {
            throw new System.ArgumentException("The number of elements requested exceeds the size of the sprite list.");
        }
        List<Sprite> randomElement = new List<Sprite>();
        List<Sprite> tempList = new List<Sprite>(list);
        System.Random random = new System.Random();
        for(int i = 0; i < count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, tempList.Count);
            randomElement.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
            if(tempList.Count == 0)
            {
                break;
            }
        }
        return randomElement;
    }
    //lấy ngẫu nhiên các hình sai trong list sprite
    public static List<Sprite> GetRandomElementsWrong<Sprite>(List<Sprite> Sourcelist, List<Sprite> CorectList, int count)
    {
        if (count > Sourcelist.Count)
        {
            throw new System.ArgumentException("The number of elements requested exceeds the size of the sprite list.");
        }
        List<Sprite> randomElement = new List<Sprite>();
        List<Sprite> tempList = new List<Sprite>(Sourcelist);
        foreach(Sprite sprite in CorectList)
        {
            tempList.Remove(sprite);
        }
        System.Random random = new System.Random();
        for (int i = 0; i < count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, tempList.Count);          
            randomElement.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
            if (tempList.Count == 0)
            {
                break;
            }
        }
        return randomElement;
    }
    private void ShuffleList(List<RotatedSprite> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            RotatedSprite value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    private GROUP_PICTURES_STATUS GetRandomGroupPicturesStatus()
    {
        System.Random random = new System.Random();
        Array values = Enum.GetValues(typeof(GROUP_PICTURES_STATUS));
        return (GROUP_PICTURES_STATUS)values.GetValue(random.Next(values.Length));
    }
    private GROUP_PICTURES_DIRECTION_STATUS GetRandomGroupPictures_direction()
    {
        System.Random random = new System.Random();
        Array values = Enum.GetValues(typeof(GROUP_PICTURES_DIRECTION_STATUS));
        return (GROUP_PICTURES_DIRECTION_STATUS)values.GetValue(random.Next(values.Length));
    }
    //nhóm chọn hình giống nhau , khác nhau
    private void InitQuestion_Alike_Ulike(string text, int randomCorrectAnswerIndex, int randomWrongAnswerIndex, QUESSTION_STATUS questionSt)
    {
        string showQuestion = text;
        string showQuestionFull = new string("");
        int randomCorrectAnswerNumber = randomCorrectAnswerIndex;
        int randomWrongAnswerNumber = randomWrongAnswerIndex;
        GROUP_PICTURES_STATUS randomGroupPictures = GetRandomGroupPicturesStatus();
        initIconList = GetInitIconList(randomGroupPictures);
        List<Sprite> randomSpriteCorrect = GetRandomElementsCorect(initIconList, randomCorrectAnswerNumber);
        List<Sprite> randomSpriteWrong = GetRandomElementsWrong(initIconList, randomSpriteCorrect, randomWrongAnswerNumber);
        if(questionSt == QUESSTION_STATUS.SELECT_A_PICTURE_NAME_IN_THE_ALL_PICTURE)
        {
            string spriteName = new string("");
            foreach(Sprite sprite in randomSpriteCorrect)
            {
                if (sprite)
                {
                    spriteName = sprite.name;
                }  
            }
            showQuestionFull = showQuestion + spriteName + " trong những hình sau.";
        }
        foreach (Sprite sprite in randomSpriteWrong)
        {
            RotatedSprite rotatedSprite = new RotatedSprite(sprite, DIRECTION_STATUS.NO_STATUS);
            if(questionSt == QUESSTION_STATUS.SELECT_ALL_THE_SAME_PICTURES || questionSt == QUESSTION_STATUS.SELECT_A_PICTURE_NAME_IN_THE_ALL_PICTURE)
            {
                iconList.Add(rotatedSprite);
            }
            else if(questionSt == QUESSTION_STATUS.NOT_SAME_ALL_PICTURES)
            {
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
            }  
        }
        foreach (Sprite sprite in randomSpriteCorrect)
        {
            RotatedSprite rotatedSprite = new RotatedSprite(sprite, DIRECTION_STATUS.NO_STATUS);
            if (questionSt == QUESSTION_STATUS.SELECT_ALL_THE_SAME_PICTURES)
            {
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
            }
            else if (questionSt == QUESSTION_STATUS.NOT_SAME_ALL_PICTURES)
            {
                iconList.Add(rotatedSprite);
            }
            else if(questionSt == QUESSTION_STATUS.SELECT_A_PICTURE_NAME_IN_THE_ALL_PICTURE)
            {
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
            }
        }
        foreach (RotatedSprite rotatedSprite in iconList)
        {
            Debug.Log("sprite " + rotatedSprite.Sprite);
            Debug.Log("Rotation " + rotatedSprite.Direction);
        }
        ShuffleList(iconList);
        foreach (RotatedSprite rotatedSprite in iconList)
        {
            Debug.Log("sprite " + rotatedSprite.Sprite);
            Debug.Log("Rotation " + rotatedSprite.Direction);
        }
        if(questionSt == QUESSTION_STATUS.SELECT_A_PICTURE_NAME_IN_THE_ALL_PICTURE)
        {
            Questions questionsNew = new Questions(currentQuestion, showQuestionFull, iconList, randomCorrectAnswerNumber);
            questionsList.Add(questionsNew);
        }
        else
        {
            Questions questionsNew = new Questions(currentQuestion, showQuestion, iconList, randomCorrectAnswerNumber);
            questionsList.Add(questionsNew);
        }   
        ShowQuestionToScreen();
    }
    //khởi tạo nhóm câu hỏi phương hướng
    private void InitQuestion_setDirection(string show_Question, DIRECTION_STATUS correct_Direction, QUESSTION_STATUS questionStatus, int randomCorrectAnswerIndex,int randomWrongAnswerIndex)
    {
        DIRECTION_STATUS correctDirection = correct_Direction;
        string showQuestion = show_Question;
        int randomCorrectAnswerNumber = randomCorrectAnswerIndex;
        int randomWrongAnswerNumber = randomWrongAnswerIndex;
        GROUP_PICTURES_DIRECTION_STATUS randomGroupPictures = GetRandomGroupPictures_direction();
        initIconList = GetInitIconList_derection(randomGroupPictures);
        List<Sprite> randomSpriteCorrect = GetRandomElementsCorect(initIconList, randomCorrectAnswerNumber);
        List<Sprite> randomSpriteWrong = GetRandomElementsWrong(initIconList, randomSpriteCorrect, randomWrongAnswerNumber);
        foreach (Sprite sprite in randomSpriteWrong)
        {
            RotatedSprite rotatedSprite = new RotatedSprite(sprite, GetRandomDirectionStatus(correctDirection));
            if (questionStatus == QUESSTION_STATUS.PICK_DOWN_DIRECTION || questionStatus == QUESSTION_STATUS.PICK_LEFT_DIRECTION ||
                questionStatus == QUESSTION_STATUS.PICK_UP_DIRECTION || questionStatus == QUESSTION_STATUS.PICK_RIGHT_DIRECTION)
            {
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
            } 
            else if(questionStatus == QUESSTION_STATUS.ALL_SHAPES_WITH_THE_SAME_ORIENTION)
            {
                iconList.Add(rotatedSprite);
            }
            else if(questionStatus == QUESSTION_STATUS.PICTURE_DIFFERENT_ORIENTATION_ALL_THE_OTHERS)
            {
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
            }
        }
        foreach (Sprite sprite in randomSpriteCorrect)
        {
            RotatedSprite rotatedSprite = new RotatedSprite(sprite, correctDirection);
            if (questionStatus == QUESSTION_STATUS.PICK_DOWN_DIRECTION || questionStatus == QUESSTION_STATUS.PICK_LEFT_DIRECTION ||
               questionStatus == QUESSTION_STATUS.PICK_UP_DIRECTION || questionStatus == QUESSTION_STATUS.PICK_RIGHT_DIRECTION)
            {
                iconList.Add(rotatedSprite);
                iconList.Add(rotatedSprite);
            }
            else if (questionStatus == QUESSTION_STATUS.ALL_SHAPES_WITH_THE_SAME_ORIENTION)
            {
                iconList.Add(rotatedSprite);
            }
            else if (questionStatus == QUESSTION_STATUS.PICTURE_DIFFERENT_ORIENTATION_ALL_THE_OTHERS)
            {
                iconList.Add(rotatedSprite);
            }
           
        }
        foreach (RotatedSprite rotatedSprite in iconList)
        {
            Debug.Log("sprite oil " + rotatedSprite.Sprite);
            Debug.Log("Rotation " + rotatedSprite.Direction);
        }
        ShuffleList(iconList);
        foreach (RotatedSprite rotatedSprite in iconList)
        {
            Debug.Log("sprite new " + rotatedSprite.Sprite);
            Debug.Log("Rotation " + rotatedSprite.Direction);
        }
        Questions questionsNew = new Questions(currentQuestion, showQuestion, iconList, randomCorrectAnswerNumber);
        questionsList.Add(questionsNew);
        ShowQuestionToScreen();
    }
    //lấy các list sprite từ sprite factory
    private List<Sprite> GetInitIconList(GROUP_PICTURES_STATUS groupPicture)
    {
        if(groupPicture == GROUP_PICTURES_STATUS.ANIMALS_GROUP)
        {
            return SpriteFactory.Animal;
        }
        else if(groupPicture == GROUP_PICTURES_STATUS.FRUITS_GROUP)
        {
            return SpriteFactory.Fruit;
        }
        else if (groupPicture == GROUP_PICTURES_STATUS.GEOMETRYS_GROUP)
        {
            return SpriteFactory.Geometry;
        }
        else if (groupPicture == GROUP_PICTURES_STATUS.HOME_APPLIANCES_GROUP)
        {
            return SpriteFactory.HomeAppliance;
        }
        else if (groupPicture == GROUP_PICTURES_STATUS.INSECTS_GROUP)
        {
            return SpriteFactory.Insect;
        }
        else if (groupPicture == GROUP_PICTURES_STATUS.LEARNING_TOOLS_GROUP)
        {
            return SpriteFactory.LearningTool;
        }
        else if (groupPicture == GROUP_PICTURES_STATUS.MEAN_OF_TRANSPORTATION_GROUP)
        {
            return SpriteFactory.MeanOfTransportation;
        }
        else if (groupPicture == GROUP_PICTURES_STATUS.VEGETABLES_GROUP)
        {
            return SpriteFactory.Vegetable;
        }
        else
        {
            return null;
        } 
    }
    private List<Sprite> GetInitIconList_derection(GROUP_PICTURES_DIRECTION_STATUS groupPicture)
    {
        if(groupPicture == GROUP_PICTURES_DIRECTION_STATUS.TREES_GROUP)
        {
            return SpriteFactory.Tree;
        }
        else if(groupPicture == GROUP_PICTURES_DIRECTION_STATUS.WORLD_WONDER_GROUP)
        {
            return SpriteFactory.WorldWonder;
        }
        else
        {
            return null;
        }
    }
    //show câu hỏi và các icon ra màn hình
    private void ShowQuestionToScreen()
    {
        Vector3 posOrigin = PosOriginIcon.transform.position;
        Vector3 posDistance = new Vector3(520, 500, 520);
        Vector3 convertToScreenPosDistance = Camera.main.ScreenToWorldPoint(posDistance);
        Vector3 posStartOrigin = new Vector3(posOrigin.x, posOrigin.y - convertToScreenPosDistance.y, posOrigin.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(posOrigin);
        for(int i = 0; i < questionsList.Count; i++)
        {
            if(questionsList[i].QuestionID == currentQuestion)
            {
                showQuestion.text = questionsList[i]._question;
                for(int j = 0; j < questionsList[i].ListRotatedSprites.Count; j++)
                {
                    if(j == 0)
                    {
                        InitGameObject(i, j, posOrigin);
                    }
                    if(j > 0 && j <= 7)
                    {
                        posOrigin = new Vector3(posOrigin.x - convertToScreenPosDistance.x, posOrigin.y, posOrigin.z);
                        InitGameObject(i, j, posOrigin);
                    }
                    else if(j > 7)
                    {
                        if(j == 8)
                        {
                            posStartOrigin = new Vector3(posStartOrigin.x, posStartOrigin.y, posStartOrigin.z);
                            InitGameObject(i, j, posStartOrigin);
                        }
                        else if(j > 8)
                        {
                            posStartOrigin = new Vector3(posStartOrigin.x - convertToScreenPosDistance.x, posStartOrigin.y, posStartOrigin.z);
                            InitGameObject(i, j, posStartOrigin);
                        }   
                    }
                    
                }
            }
        }
    }
    //khởi tạo các giá trị ban đầu cho game obj
    private void InitGameObject( int listIndexQuestion, int listIndexSprite, Vector3 posOrigin)
    {
        GameObject gameObjectNew = Instantiate(iconPrefab, posOrigin, Quaternion.identity, showIconGroup.transform);
        gameObjectNew.name = questionsList[listIndexQuestion].ListRotatedSprites[listIndexSprite].Sprite.name;
        gameObjectNew.transform.Find("Icon").GetComponent<Image>().sprite = questionsList[listIndexQuestion].ListRotatedSprites[listIndexSprite].Sprite;
        RotateGameObj(gameObjectNew, questionsList[listIndexQuestion].ListRotatedSprites[listIndexSprite].Direction);
    }
    //set các góc xoay cho game obj
    private void RotateGameObj(GameObject gameObj, DIRECTION_STATUS direction)
    {
        if(direction == DIRECTION_STATUS.UP)
        {
            gameObj.transform.rotation = gameObj.transform.rotation;
        }
        else if (direction == DIRECTION_STATUS.DOWN)
        {
            Quaternion targetRotation = Quaternion.Euler(180f, 0f, 0f); // Xoay theo trục X 180 độ (xuống dưới)
            gameObj.transform.Find("Icon").rotation = targetRotation;
        }
        else if (direction == DIRECTION_STATUS.LEFT)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 90f); // Xoay theo trục Z 90 độ (sang trái)
            gameObj.transform.Find("Icon").rotation = targetRotation;
        }
        else if (direction == DIRECTION_STATUS.RIGHT)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, -90f); // Xoay theo trục Z -90 độ (sang phải)
            gameObj.transform.Find("Icon").rotation = targetRotation;
        }
        else
        {
            gameObj.transform.rotation = gameObj.transform.rotation;
        }
    }
}
//class question
public class Questions
{ 
    public int QuestionID;
    public string _question;
    public List<RotatedSprite> ListRotatedSprites;
    public int CorrectAnswerNumber;
    public  Questions(int questionID, string showQuestion, List<RotatedSprite> icon,int  correctAnswerNumber)
    {
        QuestionID = questionID;
        ListRotatedSprites = new List<RotatedSprite>();
        _question = showQuestion;
        for(int i = 0; i < icon.Count; i++)
        {
            ListRotatedSprites.Add(icon[i]);
        }
        CorrectAnswerNumber = correctAnswerNumber;
    }
}
//class góc xoay theo ảnh
public class RotatedSprite
{
    public Sprite Sprite;
    public DIRECTION_STATUS Direction;
    public RotatedSprite (Sprite sprite, DIRECTION_STATUS direction)
    {
        Sprite = sprite;
        Direction = direction;
    }
}
//class question text
public class QuestionText
{
    public string SelectAllTheSamePictures = new string("Chọn ra tất cả những hình giống nhau trong các hình sau.");
    public string NotSameAllPictures = new string("Chọn ra hình không giống những hình còn lại.");
    public string PickUpDirection = new string("Chọn ra tất cả những hình hướng lên trong các hình sau.");
    public string PickDownDirection = new string("Chọn ra tất cả những hình hướng xuống trong các hình sau.");
    public string PickLeftDirection = new string("Chọn ra tất cả những hình hướng sang trái trong các hình sau.");
    public string PickRightDirection = new string("Chọn ra tất cả những hình hướng sang phải trong các hình sau.");
    public string AllShapesWithTheSameOriention = new string("Chọn ra tất cả những hình cùng hướng  trong các hình sau.");
    public string DirectionDifferentWithAllPictures = new string("Chọn ra tất cả những hình khác hướng trong các hình sau.");
    public string SelectAPictureNameInTheAllPicture = new string("chọn ra tất cả những hình ");
}    
