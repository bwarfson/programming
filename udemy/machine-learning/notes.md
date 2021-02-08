# Section One

[Youtube - Regression - Video](https://www.dropbox.com/s/py3ns8ltraoexfi/Youtube%20-%20Regression%20-%20Video%20Exp%20%232.mov?dl=0)

[Machine Learning Skill Track](https://sdsclub.com/learning-paths/machine-learning-track/)

[Code and data](https://drive.google.com/drive/folders/1OFNnrHRZPZ3unWdErjLHod8Ibv2FfG1d)

Simple linear regression: two variables 
Multiple linear regression: more than two variables 
Polynomial linear regression: nth degree


# Section 3: Data Preprocessing in Python

1. Import libraries
2. Import the dataset
    1. Create matrix of features
    2. create dependent variable vector
3. Replace missing data with the average
4. Encode categorical data
5. Split dataset into training set and test set
6. Feature scaling


All datasets have features and dependent variable data

Features care the columns that you are going to use to predict dependent variable
Features are independent variables
Dependent variable is what you want to predict, usually the last column in the data set


```python
# Index locator, take the indexes of the column we want to extract from the dataset
# : colon in python is range 
# :-1 means take index starting at 0 until the last column excluding the upper bound
dataset.iloc[:, :-1].values
```

**one hot encoding** consists of turning one column into multiple columns (based on the number of classes/catagories) it creates binary vectors for each of the classes

Do we have to apply feature scaling before or after splitting the dataset into training and test sets?
**Apply feature scaling after splitting the data into the training set and test set.**  
The test set is supposed to be a brand new set. Prevent information leakage on the test set.  

**Features Scaling:** put all the features on the same scale in order for some features to not be dominated by other features.  

# Simple Linear Regression

## $$y=b_0+b_1*x_1$$

- y = dependent variable
- x = independent variable
- $b_1$ = coefficient
- $b_0$ = constant

Looking at salary and experience:

$Salary = b_0 + b_1 * Experience$

$b_0$ = Constant is the point where the line crosses the horizontal axis.  0 Years experience = 30k
$b_1$ = The slope of the line.  The steeper the line the more money you make.  

