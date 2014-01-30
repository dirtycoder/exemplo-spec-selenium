#language: pt-br

Funcionalidade: Efetuar autenticação
		Para quando eu tentar efetuar login
		Enquanto usuário
		Eu tentarei logar no sistema

Cenário: Efetuar login com usuário e senha válidos
	Dado que estou na home na aplicação
	E clico em Log In
	E preencho o usuário com "usuario"
	E preencho a senha com "senha123"
	Quando clico no botão de Log In
	Então vejo "Hello usuario!"

Cenário: Tentar efetuar login com usuario e senha não cadastrados
	Dado que estou na home na aplicação
	E clico em Log In
	E preencho o usuário com "usuario2"
	E preencho a senha com "senha123"
	Quando clico no botão de Log In
	Então vejo "Invalid username or password"