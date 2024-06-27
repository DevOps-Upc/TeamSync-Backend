namespace TeamSync.API.IAM.Domain.Model.Commands;

/**
 * <summary>
 *     The sign up command
 * </summary>
 * <remarks>
 *     This command object includes the username and password to sign up
 * </remarks>
 */
public record SignUpCommand(string Username, string Password,string firstname, string lastname, string address, byte[] picture, int role, string emailAddress,
 string membership);