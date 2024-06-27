using TeamSync.API.IAM.Application.Internal.OutboundServices;
using TeamSync.API.IAM.Domain.Model.Aggregates;
using TeamSync.API.IAM.Domain.Model.Commands;
using TeamSync.API.IAM.Domain.Repositories;
using TeamSync.API.IAM.Domain.Services;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.IAM.Application.Internal.CommandServices;

/**
 * <summary>
 *     The user command service
 * </summary>
 * <remarks>
 *     This class is used to handle user commands
 * </remarks>
 */
public class UserCommandService(
    IUserRepository userRepository, 
    ITokenService tokenService,
    IHashingService hashingService,
    ExternalProfileServiceIAM externalProfileServiceIam,
    IUnitOfWork unitOfWork)
    : IUserCommandService
{
    /**
     * <summary>
     *     Handle sign in command
     * </summary>
     * <param name="command">The sign in command</param>
     * <returns>The authenticated user and the JWT token</returns>
     */
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }

    /**
     * <summary>
     *     Handle sign up command
     * </summary>
     * <param name="command">The sign up command</param>
     * <returns>A confirmation message on successful creation.</returns>
     */
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);

        var profileId = await externalProfileServiceIam.CreateProfile(command.firstname, command.lastname, command.address, command.picture,
            command.role, command.emailAddress, command.membership);
        if (profileId is null)
        {
            throw new Exception("Profile Dont create");
        }
        
        var user = new User(command.Username, hashedPassword,profileId.Value);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }
    }
}