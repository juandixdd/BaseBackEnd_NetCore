using BaseBackend.Domain.Entities;
using BaseBackend.Domain.Interfaces;

namespace BaseBackend.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    // ✅ YA NO DEVUELVE TOKEN
    public async Task RegisterAsync(string email, string password)
    {
        var existingUser = await _userRepository.GetByEmailAsync(email);

        if (existingUser != null)
            throw new Exception("User already exists");

        var passwordHash = _passwordHasher.Hash(password);

        var user = new User(email, passwordHash);

        await _userRepository.AddAsync(user);
    }

    // ✅ SOLO LOGIN GENERA TOKEN
    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
            throw new Exception("Invalid credentials");

        var isValid = _passwordHasher.Verify(password, user.PasswordHash);

        if (!isValid)
            throw new Exception("Invalid credentials");

        return _jwtTokenGenerator.GenerateToken(user);
    }
}