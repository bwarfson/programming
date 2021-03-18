# Cloud Formation

## Intrinsic Function Syntax
```yaml
Fn::Ref arg
! Ref arg
```

## Common Intrinsic Functions
| Function                                               | Purpose                                                            |  
| ------------------------------------------------------ | ------------------------------------------------------------------ |  
| `!Find­InMap [ Map, TopLev­elKey, Second­Lev­elKey` ]      | Returns values of keys in 2-level map declared in Mappings section |  
| `!GettAtt a.Arn `                                      | Get Arn attribute of resource a in this stack                      |   
| `!Impo­rtValue a`                                       | Reference export a from another stack                              |    
| `!Join [':',[­'a'­,'b']]`                                | Produces 'a:b'                                                     |
| `!Ref a`                                               | Get value of parameter or resource a in this stack                 |
| `!Select ['1',[­'a'­,'b']]`                              | Produces 'b'                                                       |
| `!Split [ ':', 'a:b' ]`                                | Produces ['a', 'b']                                                |
| `!Sub 'a-${b}'`                                        | Inject the value of b into a string                                |

You can't nest the shorthand YAML functions.

