namespace SignalRPlayground.Repositories.Users;

//This should probably be moved into a different library for referencing or perhaps using DDD is a better approach
public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserId { get; set; }
}