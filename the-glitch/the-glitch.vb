
declare global.number[0] with network priority local
declare global.number[1] with network priority local
declare global.number[2] with network priority local
declare global.number[3] with network priority low
declare global.number[4] with network priority low
declare global.number[5] with network priority local
declare global.number[6] with network priority local
declare global.number[7] with network priority low
declare global.number[8] with network priority low
declare global.object[0] with network priority low
declare global.object[1] with network priority local
declare global.object[2] with network priority local
declare global.object[3] with network priority low
declare global.object[4] with network priority low
declare global.object[5] with network priority low
declare global.object[6] with network priority low
declare global.object[7] with network priority low
declare global.object[8] with network priority low
declare global.object[9] with network priority low
declare global.object[10] with network priority low
declare global.object[11] with network priority low
declare global.object[12] with network priority local
declare global.object[13] with network priority low
declare global.object[14] with network priority local
declare global.object[15] with network priority low
declare global.player[0] with network priority low
declare global.player[1] with network priority local
declare global.player[2] with network priority local
declare global.player[3] with network priority local
declare global.player[4] with network priority low
declare global.team[0] with network priority low
declare global.team[1] with network priority low
declare global.team[2] with network priority low
declare global.team[3] with network priority low
declare global.team[4] with network priority low
declare global.team[5] with network priority low
declare global.team[6] with network priority low
declare global.team[7] with network priority low
declare global.timer[0] = script_option[2]
declare global.timer[1] = 5
declare player.number[0] with network priority low
declare player.timer[0] = 1
declare player.timer[1] = 7
declare object.number[0] with network priority local
declare object.number[1] with network priority low
declare object.number[2] with network priority local
declare object.number[3] with network priority low
declare object.number[4] with network priority low
declare object.number[5] with network priority local
declare object.number[6] with network priority low
declare object.number[7] with network priority low
declare object.object[0] with network priority low
declare object.object[1] with network priority low
declare object.object[2] with network priority low
declare object.object[3] with network priority local
declare object.timer[2] = 3

function trigger_0()
   current_object.detach()
   if current_object.number[5] == 0 then 
      current_object.number[5] = current_object.spawn_sequence
      if current_object.spawn_sequence < -10 then 
         current_object.number[5] += 101
         current_object.number[5] *= 2
         if current_object.spawn_sequence > -71 then 
            current_object.number[5] *= 2
            if current_object.spawn_sequence > -41 then 
               current_object.number[5] *= 3
               current_object.number[5] /= 2
            end
         end
      end
      current_object.number[5] *= 10
      current_object.number[5] += 100
      if current_object.spawn_sequence < -10 then 
         current_object.number[5] += 1000
         if current_object.spawn_sequence > -71 then 
            current_object.number[5] += -600
            if current_object.spawn_sequence > -41 then 
               current_object.number[5] += -1200
            end
         end
      end
      if current_object.spawn_sequence == -10 then 
         current_object.number[5] = 1
      end
      current_object.set_scale(current_object.number[5])
      current_object.copy_rotation_from(current_object, false)
      if current_object.object[2] != no_object then 
         current_object.copy_rotation_from(current_object, true)
         current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
      end
      current_object.number[2] = 1
   end
end

for each player do
   if current_player.is_elite() then 
      current_player.set_loadout_palette(elite_tier_1)
   end
   if not current_player.is_elite() then 
      current_player.set_loadout_palette(spartan_tier_1)
   end
end

on init: do
   for each player do
      current_player.timer[1].set_rate(-100%)
   end
end

do
   global.timer[0].set_rate(-100%)
   global.timer[1].set_rate(-100%)
end

for each player do
   if current_player.number[0] == 0 then 
      game.show_message_to(current_player, announce_juggernaut, "The Glitch")
      if game.score_to_win != 0 then 
         current_player.set_round_card_title("Kill the Glitch.\n%n points to win.", game.score_to_win)
      end
      if game.score_to_win == 0 then 
         current_player.set_round_card_title("Kill the Glitch.")
      end
      current_player.number[0] = 1
   end
   if current_player.timer[1].is_zero() then 
      current_player.timer[1].reset()
      game.show_message_to(current_player, none, "Created by mini nt  (v0.95)")
   end
end

for each player do
   current_player.timer[0].set_rate(0%)
   if global.player[0] == current_player then 
      global.object[1] = global.player[0].biped
      if not global.object[1] == no_object then 
         current_player.timer[0].set_rate(-100%)
         if current_player.timer[0].is_zero() then 
            current_player.script_stat[0] += 1
            current_player.timer[0].reset()
         end
      end
   end
end

if global.timer[1].is_zero() and not global.player[0] == no_player and not global.player[0].is_not_respawning() then 
   global.player[0] = no_player
   global.timer[1].reset()
   global.timer[1].set_rate(-100%)
end

on host migration: do
   global.timer[1].reset()
   global.timer[1].set_rate(-100%)
end

for each player do
   global.player[1] = global.player[0]
   global.player[2] = no_player
   global.player[3] = current_player
   global.number[2] = 0
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      global.player[2] = current_player.try_get_killer()
      if global.player[3] == global.player[1] and global.player[2] == global.player[3] or global.player[2] == no_player then 
         global.number[2] = 1
      end
      if not global.number[2] == 1 and global.player[2] == global.player[1] then 
         global.player[2].score += script_option[1]
         send_incident(kill_as_juggernaut, global.player[2], global.player[3])
      end
      if current_player == global.player[1] and not global.number[2] == 1 then 
         global.player[2].score += script_option[0]
         send_incident(juggernaut_kill, global.player[2], global.player[1])
         global.player[1].set_round_card_title("Kill the Glitch.\n%n points to win.", game.score_to_win)
         global.player[0] = global.player[2]
         send_incident(new_juggernaut, global.player[0], all_players)
         global.timer[0].reset()
         global.timer[0].set_rate(-100%)
         global.player[0].biped.remove_weapon(primary, false)
         global.player[0].biped.remove_weapon(secondary, false)
         global.player[0].biped.add_weapon(needle_rifle, force)
         global.player[0].biped.shields = 200
         global.player[0].frag_grenades = 0
         global.player[0].plasma_grenades = 0
         global.object[0].delete()
         global.object[0] = global.player[0].biped.place_at_me(particle_emitter_fire, none, never_garbage_collect, 0, 0, 0, none)
         global.object[0].attach_to(global.player[0].biped, 0, 0, 5, absolute)
      end
   end
end

for each player randomly do
   if global.timer[1].is_zero() then 
      global.player[1] = global.player[0]
      global.object[1] = global.player[0].biped
      if global.player[0] == no_player and not current_player == global.player[1] then 
         global.object[2] = current_player.biped
         if not global.object[2] == no_object and not current_player.biped.is_out_of_bounds() then 
            global.player[0] = current_player
            send_incident(new_juggernaut, global.player[0], all_players)
            global.player[0].biped.remove_weapon(primary, false)
            global.player[0].biped.remove_weapon(secondary, false)
            global.player[0].biped.add_weapon(needle_rifle, force)
            global.player[0].biped.shields = 200
            global.player[0].frag_grenades = 0
            global.player[0].plasma_grenades = 0
            global.timer[0].reset()
            global.timer[0].set_rate(-100%)
            global.object[0].delete()
            global.object[0] = global.player[0].biped.place_at_me(particle_emitter_fire, none, never_garbage_collect, 0, 0, 0, none)
            global.object[0].attach_to(global.player[0].biped, 0, 0, 5, absolute)
         end
      end
   end
end

do
   for each player do
      current_player.biped.set_waypoint_icon(none)
      current_player.biped.set_waypoint_priority(low)
   end
   global.player[0].apply_traits(script_traits[0])
   global.player[0].biped.set_waypoint_icon(bullseye)
   global.player[0].biped.set_waypoint_priority(high)
   global.player[0].set_round_card_title("You are the Glitch")
   if not global.timer[0].is_zero() then 
      global.player[0].apply_traits(script_traits[1])
      global.player[0].biped.set_waypoint_icon(skull)
   end
end

for each object with label 2 do
   current_object.number[0] = 1
   global.player[1] = no_player
   global.player[1] = current_object.try_get_carrier()
   if global.player[1] == global.player[0] then 
      current_object.number[0] = 0
   end
end

if not global.player[0] == no_player then 
   global.object[1] = no_object
   global.object[1] = global.player[0].try_get_weapon(secondary)
   if not global.object[1] == no_object and not global.object[1].is_of_type(needle_rifle) then 
      global.player[0].biped.remove_weapon(secondary, false)
   end
end

if not global.player[0] == no_player then 
   global.object[1] = no_object
   global.object[1] = global.player[0].try_get_weapon(primary)
   if not global.object[1].is_of_type(needle_rifle) then 
      global.player[0].biped.add_weapon(needle_rifle, force)
   end
end

if not global.player[0] == no_player then
   global.object[1] = no_object
   global.object[1] = global.player[0].try_get_weapon(primary)
   if global.object[1].is_of_type(needle_rifle) then 
      global.player[0].biped.remove_weapon(primary, true)
      global.player[0].biped.add_weapon(needle_rifle, force)
   end
end

for each object with label 2 do
   if current_object.number[0] == 1 then 
      current_object.delete()
   end
end

if game.round_time_limit > 0 and game.round_timer.is_zero() then 
   game.end_round()
end

for each player do
   current_player.team = team[0]
   if current_player == global.player[0] then 
      current_player.team = team[1]
   end
end

for each player do
   if not global.player[0] == no_player then 
      global.object[1] = global.player[0].biped
      if global.object[1] == no_object then 
         global.player[0] = no_player
      end
   end
end

for each object with label 5 do
   current_object.delete()
end

for each player do
   global.object[1] = current_player.biped
   if global.object[1] == no_object then 
      current_player.team = no_team
   end
end

for each object do
   if not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) and current_object.team == team[7] then 
      current_object.set_invincibility(1)
   end
end

for each player do
   if script_option[3] == 1 then 
      current_player.set_co_op_spawning(true)
   end
   if script_option[4] == 1 then 
      current_player.biped.set_invincibility(1)
   end
end

for each object with label "scale" do
   if current_object.number[2] == 0 then 
      if current_object.team == team[2] then 
         current_object.object[2] = current_object.place_at_me(heavy_barrier, none, never_garbage_collect, 0, 0, 0, none)
         if current_object.object[2] == no_object then 
            current_object.object[2] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
         end
      end
      if current_object.team == team[3] then 
         current_object.object[2] = current_object.place_at_me(monitor, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.object[2] != no_object then 
         current_object.object[2].set_invincibility(1)
         current_object.object[2].set_scale(50)
         current_object.object[2].attach_to(current_object, 0, 0, 0, relative)
         current_object.object[2].detach()
         current_object.object[2].copy_rotation_from(current_object, false)
         current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
      end
      trigger_0()
   end
end

for each object with label "attach_base" do
   if current_object.spawn_sequence != 0 then 
      global.object[5] = no_object
      global.object[5] = current_object
      global.number[8] = current_object.spawn_sequence
      global.number[8] *= -1
      for each object with label "attachment" do
         if current_object.spawn_sequence != 0 and global.object[5].spawn_sequence == current_object.spawn_sequence or global.number[8] == current_object.spawn_sequence and current_object.number[1] == 0 then 
            if current_object.spawn_sequence < 0 then 
               global.object[6] = current_object
               for each object do
                  global.number[7] = current_object.get_distance_to(global.object[6])
                  global.player[4] = current_object.try_get_carrier()
                  if global.number[7] == 0 and global.player[4] == no_player and global.object[6] != current_object and not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) then 
                     current_object.detach()
                     current_object.attach_to(global.object[5], 0, 0, 5, relative)
                     if current_object.is_of_type(warthog_turret_rocket) or current_object.is_of_type(warthog_turret_gauss) or current_object.is_of_type(warthog_turret) or current_object.is_of_type(shade_gun_plasma) then 
                        current_object.object[0] = current_object.place_at_me(flag_stand, none, none, 0, 0, 0, none)
                        current_object.object[0].set_scale(1)
                        current_object.detach()
                        current_object.attach_to(current_object.object[0], 0, 0, 0, relative)
                        current_object.object[0].attach_to(global.object[5], 0, 0, 5, relative)
                        global.object[5].object[0] = current_object
                        current_object.object[0].set_shape(box, 5, 5, 10, 0)
                     end
                  end
               end
               current_object.attach_to(global.object[5], 0, 0, 0, relative)
               current_object.number[1] = 1
               if current_object.spawn_sequence < -50 then 
                  current_object.set_scale(1)
               end
            end
            if current_object.spawn_sequence > 74 then 
               global.object[6] = current_object.place_at_me(flag_stand, none, none, 0, 0, 0, troop)
               global.object[6].set_scale(1)
               global.object[6].attach_to(global.object[5], 0, 0, 0, relative)
               current_object.attach_to(global.object[6], 0, 0, 0, relative)
               current_object.number[1] = 1
            end
            if current_object.spawn_sequence > 0 then 
               current_object.attach_to(global.object[5], 0, 0, 0, relative)
               current_object.number[1] = 1
            end
         end
      end
      for each object do
         if global.object[5].spawn_sequence < 0 then 
            global.object[5].set_shape_visibility(everyone)
            if global.object[5].team == current_object.team or global.object[5].team == neutral_team and global.object[5].shape_contains(current_object) and not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) then 
               current_object.attach_to(global.object[5], 0, 0, 0, relative)
            end
         end
      end
   end
end

for each object with label "spawner" do
   if current_object.object[0] == no_object then 
      current_object.number[0] = current_object.spawn_sequence
      if current_object.spawn_sequence == 1 then 
         current_object.object[0] = current_object.place_at_me(bomb, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 2 then 
         current_object.object[0] = current_object.place_at_me(covenant_bomb, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 3 then 
         current_object.object[0] = current_object.place_at_me(flag, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 4 then 
         current_object.object[0] = current_object.place_at_me(skull, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 5 then 
         current_object.object[0] = current_object.place_at_me(unsc_data_core, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 6 then 
         current_object.object[0] = current_object.place_at_me(covenant_power_core, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 7 then 
         current_object.object[0] = current_object.place_at_me(spartan, none, never_garbage_collect, 0, 0, 0, player_skull)
      end
      if current_object.spawn_sequence == 8 then 
         current_object.object[0] = current_object.place_at_me(elite, none, never_garbage_collect, 0, 0, 0, jetpack)
      end
      if current_object.spawn_sequence == 9 then 
         current_object.object[0] = current_object.place_at_me(pelican_scenery, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 10 then 
         current_object.object[0] = current_object.place_at_me(phantom_scenery, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 11 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 12 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret_gauss, none, never_garbage_collect, 0, 0, 0, none)
         if current_object.team == team[1] and current_object.object[1] == no_object then 
            current_object.object[1] = current_object.place_at_me(flag_stand, none, never_garbage_collect, 0, 0, 0, none)
            current_object.object[2] = current_object.place_at_me(shade, none, never_garbage_collect, 0, 0, 0, none)
            current_object.object[2].set_shape(cylinder, 10, 10, 0)
            global.object[13] = current_object.object[2]
            for each object do
               if global.object[13].shape_contains(current_object) and current_object.is_of_type(shade_gun_plasma) then 
                  current_object.delete()
               end
            end
            current_object.object[2].set_scale(10)
            current_object.object[1].set_scale(1)
            current_object.object[2].attach_to(current_object.object[0], 0, 0, 0, relative)
            current_object.object[2].detach()
            current_object.object[1].attach_to(current_object.object[2], 0, 0, 0, relative)
            current_object.object[0].attach_to(current_object.object[1], 0, 0, 0, relative)
         end
      end
      if current_object.spawn_sequence == 13 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret_rocket, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 14 then 
         current_object.object[0] = current_object.place_at_me(phantom, none, never_garbage_collect, 0, 0, 0, none)
         current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      end
      if current_object.spawn_sequence == 15 then 
         current_object.object[0] = current_object.place_at_me(longsword, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 16 then 
         current_object.object[0] = current_object.place_at_me(covenant_power_module_stand, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 17 then 
         current_object.object[0] = current_object.place_at_me(unsc_data_core_holder, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 18 then 
         current_object.object[0] = current_object.place_at_me(longsword, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == -3 then 
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(1, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(2, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(3, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(4, 1)
         end
      end
      if current_object.spawn_sequence == -4 then 
         current_object.set_waypoint_visibility(everyone)
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(5, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(6, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(7, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(8, 1)
         end
      end
      current_object.object[0].copy_rotation_from(current_object, true)
      if current_object.team == team[0] and current_object.spawn_sequence != -5 then 
         current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      end
   end
   if current_object.spawn_sequence == -5 and current_object.object[0] == no_object then 
      current_object.object[0] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
      if current_object.object[0] == no_object then 
         current_object.object[0] = current_object.place_at_me(monitor, none, never_garbage_collect, 0, 0, 0, none)
      end
      current_object.object[0].set_invincibility(1)
      current_object.object[0].set_scale(50)
      current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      current_object.object[0].detach()
      current_object.object[0].copy_rotation_from(current_object, true)
      current_object.attach_to(current_object.object[0], 0, 0, 0, relative)
      current_object.object[0].copy_rotation_from(current_object.object[0], false)
   end
   if current_object.spawn_sequence == -6 or current_object.spawn_sequence == -7 and current_object.number[2] == 0 then 
      global.object[7] = no_object
      global.object[7] = current_object
      for each object do
         global.number[7] = current_object.get_distance_to(global.object[7])
         if global.number[7] == 0 and global.object[7] != current_object then 
            if global.object[7].spawn_sequence == -6 then 
               current_object.delete()
            end
            if global.object[7].spawn_sequence == -7 then 
               current_object.attach_to(global.object[7], 0, 0, 0, relative)
            end
            global.object[7].number[2] = 1
         end
      end
   end
   if current_object.spawn_sequence == -8 or current_object.spawn_sequence == -9 then 
      global.object[12] = current_object
      for each object do
         if global.object[12].shape_contains(current_object) and global.object[12].team == current_object.team or global.object[12].team == neutral_team then 
            if global.object[12].spawn_sequence == -8 then 
               current_object.set_invincibility(1)
            end
            if global.object[12].spawn_sequence == -9 then 
               current_object.set_invincibility(0)
            end
         end
      end
   end
end

for each object with label "bro_spawn_loc" do
   current_object.set_invincibility(1)
   current_object.set_pickup_permissions(no_one)
   current_object.set_spawn_location_fireteams(all)
   current_object.set_spawn_location_permissions(allies)
   for each player do
      if current_object.team == current_player.team or current_object.team == neutral_team then 
         current_player.set_primary_respawn_object(current_object)
      end
   end
end

on local: do
   for each object with label "object_by_index" do
      if current_object.timer[3].is_zero() then 
         current_object.object[3].detach()
         current_object.object[3].copy_rotation_from(current_object, true)
         current_object.timer[3].reset()
      end
      if current_object.object[3] == no_object then 
         current_object.timer[3].set_rate(-100%)
         global.number[5] = current_object.spawn_sequence
         global.number[5] += 100
         global.object[14] = no_object
         global.number[6] = 0
         for each object do
            if not current_object.is_of_type(monitor) and not current_object.is_of_type(flag_stand) and not current_object.is_of_type(kill_ball) and not current_object.is_of_type(elite) and not current_object.is_of_type(spartan) and not current_object.is_of_type(landmine) and not current_object.is_of_type(hill_marker) and not current_object.is_of_type(capture_plate) then 
               if global.number[6] == global.number[5] then 
                  global.object[14] = current_object
               end
               global.number[6] += 1
            end
         end
         current_object.object[3] = global.object[14]
         current_object.object[3].copy_rotation_from(current_object, true)
         current_object.object[3].attach_to(current_object, 0, 0, 0, relative)
      end
   end
   for each object with label "scale" do
      if current_object.number[2] == 0 then 
         if current_object.team == team[2] or current_object.team == team[3] and current_object.object[2] != no_object then 
            trigger_0()
            current_object.copy_rotation_from(current_object, true)
            current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
         end
         if current_object.team != team[2] and current_object.team != team[3] then 
            trigger_0()
         end
      end
      if current_object.is_of_type(hill_marker) then 
         current_object.set_shape_visibility(everyone)
         if current_object.team == team[7] or current_object.team == team[5] then 
            current_object.number[5] = current_object.spawn_sequence
            if current_object.spawn_sequence == 0 then 
               current_object.number[5] = 100
            end
            if current_object.spawn_sequence < 0 then 
               current_object.number[5] *= -1
               current_object.number[5] += 100
            end
         end
         global.object[15] = current_object
         for each object do
            if global.object[15].team == current_object.team or global.object[15].team == neutral_team or global.object[15].team == team[5] or global.object[15].team == team[6] or global.object[15].team == team[7] and global.object[15].shape_contains(current_object) and global.object[15] != current_object and current_object.number[7] != 9999 then 
               current_object.set_scale(global.object[15].number[5])
               current_object.copy_rotation_from(current_object, false)
               if global.object[15].team == team[6] or global.object[15].team == team[7] then 
                  current_object.number[7] = 9999
               end
            end
         end
      end
   end
   for each object with label "spawner" do
      if current_object.spawn_sequence == -3 then 
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(1, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(2, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(3, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(4, 1)
         end
      end
      if current_object.spawn_sequence == -4 then 
         current_object.set_waypoint_visibility(everyone)
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(5, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(6, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(7, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(8, 1)
         end
      end
   end
end
