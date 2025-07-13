DROP TABLE IF EXISTS dietary_supplements_vitamines;
DROP TABLE IF EXISTS vitamines_forms;
DROP TABLE IF EXISTS dietary_supplements;
DROP TABLE IF EXISTS forms;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS vitamines;

CREATE TABLE users(
	id SERIAL PRIMARY KEY,
	name CHARACTER VARYING(100),
	login CHARACTER VARYING(50),
	password CHARACTER VARYING(100)
);

CREATE TABLE vitamines(
	id SERIAL PRIMARY KEY,
	title CHARACTER VARYING(30),
	daily_intake DECIMAL,
	unit CHARACTER VARYING(30)
);

CREATE TABLE forms(
	id SERIAL PRIMARY KEY,
	user_id INTEGER REFERENCES users(id),
	create_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE vitamines_forms(
	vitamine_id INTEGER REFERENCES vitamines(id),
	form_id INTEGER REFERENCES forms(id),
	intake DECIMAL,
	PRIMARY KEY(vitamine_id, form_id)
);

CREATE TABLE dietary_supplements(
	id SERIAL PRIMARY KEY,
	title CHARACTER VARYING(100),
	daily_intake DECIMAL,
	tablets_count INTEGER,
	price DECIMAL
);

CREATE TABLE dietary_supplements_vitamines(
	dietary_supplement_id INTEGER REFERENCES dietary_supplements(id),
	vitamine_id INTEGER REFERENCES vitamines(id),
	volume_per_tablet DECIMAL,
	PRIMARY KEY (dietary_supplement_id, vitamine_id)
);