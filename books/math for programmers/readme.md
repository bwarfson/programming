# 1 Learning math with code

In programming, we call the functions that behave like mathematical functions pure functions . For example, the square function f(x) = x2 takes a number and returns the product of the number with itself. When you evaluate f(3), the result is 9.

In math, as in Python, functions are data that you can manipulate independently and even pass to other functions.

Math can be intimidating because it is abstract. Remember, as in any well-written software, the abstraction is introduced for a reason: it helps you organize and communicate bigger and more powerful ideas. When you grasp these ideas and translate them into code, you’ll open up some exciting possibilities.

Summary
* There are interesting and lucrative applications of math in many software engineering domains.
* Math can help you quantify a trend for data that changes over time, for instance, to predict the movement of a stock price.
* Different types of functions convey different kinds of qualitative behavior. For instance, an exponential depreciation function means that a car loses a percentage of its resale value with each mile driven rather than a fixed amount.
* Tuples of numbers (called vectors) represent multidimensional data. Specifically, 3D vectors are triples of numbers and can represent points in space. You can build complex 3D graphics by assembling triangles specified by vectors.
* Calculus is the mathematical study of continuous change, and many of the laws of physics are written in terms of calculus equations that are called differential equations.
* It’s hard to learn math from traditional textbooks! You learn math by exploration, not as a straightforward march through definitions and theorems.
* As a programmer, you’ve already trained yourself to think and communicate precisely; this skill will help you learn math as well.


# Part 1. Vectors and graphics
## 2 Drawing with 2D vectors

> At a very high level, linear algebra is the branch of math dealing with computations on multi-dimensional data. The concept of “dimension” is a geometric one; you probably intuitively know what I mean when I say “a square is 2-dimensional” while “a cube is 3-dimensional.” Among other things, linear algebra lets us turn geometric ideas about dimension into things we can compute concretely.

> The most basic concept in linear algebra is that of a vector, which you can think of as a data point in some multi-dimensional space. For instance, you’ve probably heard of the 2-dimensional (2D) coordinate plane in high school geometry and algebra. As we’ll cover in chapter 2, vectors in 2D correspond to points in the plane, which can be labeled by ordered pairs of numbers of the form (x, y). In chapter 3, we’ll consider 3-dimensional (3D) space, whose vectors (points) can be labeled by triples of numbers in the form (x, y, z). In both cases, we see we can use collections of vectors to define geometric shapes, which can, in turn, be converted into interesting graphics.

**linear algebra:**  At a very high level, linear algebra is the branch of math dealing with computations on multi-dimensional data.

**vector:**  which you can think of as a data point in some multi-dimensional space.  For instance, you’ve probably heard of the 2-dimensional (2D) coordinate plane in high school geometry and algebra.

**linear transformation:**  A linear transformation is a kind of function that takes a vector as input and returns a vector as output, while preserving the geometry (in a special sense) of the vectors involved. For instance, if a collection of vectors (points) lie on a straight line in 2D, after applying a linear transformation, they will still lie on a straight line.

**matrices:**  which are rectangular arrays of numbers that can represent linear transformations.
systems of linear equations:  In general, linear equations tell us where lines, planes, or higher-dimensional generalizations intersect in a vector space. 

**vector mathematics:**  For instance, a user tracked on a website can have hundreds of measurable attributes, which describe usage patterns. Grappling with these problems in graphics, physics, and data analysis requires a framework for dealing with data in higher dimensions.

**plane:**  In the language of math, a flat, 2D space is referred to as a plane. 

you can describe locations in 2D by two pieces of information: **their vertical and horizontal positions**. 

To describe the location of points in the plane, you need a reference point. We call that special reference point the **origin**.

> Any time a 2D or 3D drawing is displayed by a computer, from my modest dinosaur to a feature-length Pixar movie, it is defined by points−or vectors−connected to show the desired shape. To create the drawing you want, you need to pick vectors in the right places, requiring careful measurement.

### How to measure vectors in the plane?

> The numbers 6 and 4 are called the x- and y-coordinates of the point, and this is enough to tell us exactly what point we’re talking about. We typically write coordinates as an ordered pair(or tuple ) with the x-coordinate first and the y-coordinate second, for example, (6, 4)

> With a ruler, we can measure one dimension such as the length of an object. To measure in two dimensions, we need two rulers . These rulers are called **axes** (the singular is axis), and we lay them out in the plane perpendicular to one another, intersecting at the origin. The horizontal axis is called the x-axis and the vertical one is called the y-axis.

> we can add **grid lines** perpendicular to the axes that show where points lie relative to them. By convention, we place the origin at tick 0 on both the x- and y-axes 

> We typically write coordinates as an ordered pair(or tuple ) with the x-coordinate first and the y-coordinate second, for example, (6, 4).

**Exercise 2.1:** What are the x- and y-coordinates of the point at the tip of the dinosaur’s toe?
Solution: (−1, −4)

**Exercise 2.2:** Draw the point in the plane and the arrow corresponding to the point (2, −2).
```python
dino_vectors = [(2,-2)]
draw(
    Points(*dino_vectors),
    Arrow((2,-2), color=black)
)
```

**Exercise 2.3:** By looking at the locations of the dinosaur’s points, infer the remaining vectors not included in the dino_vectors list. For instance, I already included (6, 4), which is the tip of the dinosaur’s tail, but I didn’t include the point (−5, 3), which is a point on the dinosaur’s nose. When you’re done, dino_vectors should be a list of 21 vectors represented as coordinate pairs.

```python
dino_vectors = [(6,4), (3,1), (1,2), (−1,5), (−2,5), (−3,4), (−4,4), 
    (−5,3), (−5,2), (−2,2), (−5,1), (−4,0), (−2,1), (−1,0), (0,−3), 
    (−1,−4), (1,−4), (2,−3), (1,−2), (3,−1), (5,1)
]
```

**Exercise 2.4:** Draw the dinosaur with the dots connected by constructing a Polygon object with the dino_vectors as its vertices.

```python
dino_vectors = [(6,4), (3,1), (1,2), (−1,5), (−2,5), (−3,4), (−4,4), 
    (−5,3), (−5,2), (−2,2), (−5,1), (−4,0), (−2,1), (−1,0), (0,−3), 
    (−1,−4), (1,−4), (2,−3), (1,−2), (3,−1), (5,1)
]
draw(
    Points(*dino_vectors),
    Polygon(*dino_vectors)
)
```

**Exercise 2.5:** Draw the vectors (x,x**2) for x in the range from x = −10 to x = 11) as points (dots) using the draw function. What is the result?
```python
draw(
    Points(*[(x,x**2) for x in range(−10,11)]),
    grid=(1,10),
    nice_aspect_ratio=False
)
```

### 2.2 Plane vector arithmetic

**vector addition**: Vector addition is simple to calculate: given two input vectors, you add their x-coordinates to get the resulting x-coordinate and then you add their y-coordinates to get the resulting y-coordinate. Creating a new vector with these summed coordinates gives you the vector sum of the original vectors. For instance, (4, 3) + (−1, 1) = (3, 4) because 4 + (−1) = 3 and 3 + 1 = 4.