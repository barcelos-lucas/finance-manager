PRAGMA foreign_keys = ON;

-- users
CREATE TABLE IF NOT EXISTS users (
    id TEXT PRIMARY KEY,
    name TEXT NOT NULL,
    email TEXT NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- contas pagar
CREATE TABLE IF NOT EXISTS contas_pagar (
    id TEXT PRIMARY KEY,
    user_id TEXT NOT NULL,
    descricao TEXT NOT NULL,
    valor DECIMAL(10,2) NOT NULL CHECK (valor >= 0),
    data_vencimento DATE NOT NULL,
    status TEXT NOT NULL CHECK (status IN ('pendente','paga')),
    categoria TEXT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);

-- contas receber
CREATE TABLE IF NOT EXISTS contas_a_receber (
    id TEXT PRIMARY KEY,
    user_id TEXT NOT NULL,
    descricao TEXT NOT NULL,
    valor DECIMAL(10,2) NOT NULL CHECK (valor >= 0),
    data_recebimento DATE NOT NULL,
    status TEXT NOT NULL CHECK (status IN ('pendente','recebido')),
    categoria TEXT NOT NULL,
    recorrente BOOLEAN NOT NULL DEFAULT 0,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);

-- cc
CREATE TABLE IF NOT EXISTS cartoes_credito (
    id TEXT PRIMARY KEY,
    user_id TEXT NOT NULL,
    nome TEXT NOT NULL,
    bandeira TEXT NOT NULL,
    limite_total DECIMAL(12,2) NOT NULL CHECK (limite_total >= 0),
    limite_disponivel DECIMAL(12,2) NOT NULL CHECK (limite_disponivel >= 0),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);

-- compras cc
CREATE TABLE IF NOT EXISTS compras_credito (
    id TEXT PRIMARY KEY,
    user_id TEXT NOT NULL,
    cartao_id TEXT NOT NULL,
    descricao TEXT NOT NULL,
    valor_total DECIMAL(12,2) NOT NULL CHECK (valor_total >= 0),
    data_compra DATE NOT NULL,
    categoria TEXT NOT NULL,
    parcelas INTEGER NOT NULL CHECK (parcelas >= 1),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (cartao_id) REFERENCES cartoes_credito(id) ON DELETE CASCADE
);

-- parcelas 
CREATE TABLE IF NOT EXISTS parcelas_compras (
    id TEXT PRIMARY KEY,
    compra_id TEXT NOT NULL,
    numero_parcela INTEGER NOT NULL CHECK (numero_parcela >= 1),
    valor DECIMAL(12,2) NOT NULL CHECK (valor >= 0),
    data_vencimento DATE NOT NULL,
    paga BOOLEAN NOT NULL DEFAULT 0,
    FOREIGN KEY (compra_id) REFERENCES compras_credito(id) ON DELETE CASCADE
);
